using System;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Data;

namespace SupermarketModel
{
    public static class XmlUtils
    {
        public static void LoadExpensesIntoDatabases(string fileName)
        {
            using (var context = new SupermarketContext())
            {
                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    Vendor currentVendor = null;
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "sale")
                            {
                                string vendorName = reader.GetAttribute("vendor");
                                currentVendor = context.Vendors.First(x => x.Name == vendorName);
                            }
                            else if (reader.Name == "expenses")
                            {
                                var expense = new Expense
                                {
                                    Date = DateTime.ParseExact(reader.GetAttribute("month"), "MMM-yyyy", CultureInfo.InvariantCulture),
                                    Sum = decimal.Parse(reader.ReadInnerXml()),
                                    VendorId = currentVendor.Id
                                };

                                var expenses = context.Expenses
                                    .Where(x => x.Date == expense.Date &&
                                        x.VendorId == expense.VendorId);
                                if (expenses.Count() == 0)
                                {
                                    context.Expenses.Add(expense);
                                }

                                ExpenseMongo expenseMongo = new ExpenseMongo(expense.Date, expense.Sum, expense.VendorId);
                                SaveToMongo<ExpenseMongo>(expenseMongo);
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public static void GenerateSalesReport()
        {
            XElement salesReport = new XElement("sales");
            using (var context = new SupermarketContext())
            {
                var vendors = (from s in context.Reports
                               join p in context.Products on s.ProductId equals p.Id
                               join v in context.Vendors on p.VendorId equals v.Id
                               select v).Distinct();

                foreach (var vendor in vendors)
                {
                    salesReport.Add(CreateSaleElement(vendor.Id, vendor.Name));
                }
            }

            salesReport.Save("../../../Resources/XmlReports/Sales-by-Vendors-report.xml");
        }

        private static XElement CreateSaleElement(int vendorId, string vendorName)
        {
            using (var context = new SupermarketContext())
            {
                var entries = from s in context.Reports
                              join p in context.Products on s.ProductId equals p.Id
                              join v in context.Vendors on p.VendorId equals v.Id
                              where v.Id == vendorId
                              group s by s.Date into y
                              select new
                              {
                                  Date = y.Key,
                                  Sum = y.Sum(x => x.Sum)
                              };

                XElement sale = new XElement("sale");
                foreach (var entry in entries)
                {
                    sale.SetAttributeValue("vendor", vendorName);

                    sale.Add(new XElement("summary",
                        new XAttribute("date",
                            entry.Date.ToString("dd-MMM-yyyy", CultureInfo.InvariantCulture)),
                            new XAttribute("total-sum", entry.Sum.ToString("0.00"))));
                }

                return sale;
            }
        }

        private static void SaveToMongo<T>(ExpenseMongo expense)
        {
            try
            {
                var result = MongoDBProvider.db.GetCollection<T>(typeof(T).Name).Save(expense, SafeMode.True);
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }
    }
}
