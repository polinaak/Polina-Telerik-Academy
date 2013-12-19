using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Data;
using SupermarketModel;

namespace MongoDB.ConsoleClient
{
    public static class MongoUtils
    {
        static void Main(string[] args)
        {
            GetDataFromSqlServer();
            GetDataFromMongoDB();
        }

        public static void GetDataFromSqlServer()
        {
            SupermarketContext db = new SupermarketContext();
            
            var salesInfo = from sale in db.Reports
                            select new
                                {
                                    ProductId = sale.ProductId,
                                    ProductName = sale.Product.Name,
                                    VendorName = sale.Product.Vendor.Name,
                                    Quantity = sale.Quantity,
                                    Sum = sale.Sum
                                };

            foreach (var sale in salesInfo)
            {
                Product product = new Product();
                product.ProductId = sale.ProductId;
                product.ProductName = sale.ProductName;
                product.VendorName = sale.VendorName;
                product.TotalQuantitySold = sale.Quantity;                
                product.TotalIncomes = sale.Sum;
                
                SaveData<Product>(product);
            }
        }

        public static void GetDataFromMongoDB()
        {
            var products = LoadData<Product>().ToList();

            foreach (var product in products)
            {
                using (var writer = new StreamWriter(@"..\..\..\Resources\JsonReports\" + product.ProductId + ".json"))
                {
                    var sb = new StringBuilder();

                    sb.Append("{").AppendLine();
                    sb.AppendFormat("\tproduct-id: {0},", product.ProductId).AppendLine();
                    sb.AppendFormat("\tproduct-name: {0},", product.ProductName).AppendLine();
                    sb.AppendFormat("\tvendor-name: {0},", product.VendorName).AppendLine();
                    sb.AppendFormat("\tquantity: {0},", product.TotalQuantitySold).AppendLine();
                    sb.AppendFormat("\tincome: {0},", product.TotalIncomes).AppendLine();
                    sb.Append("}").AppendLine();

                    writer.WriteLine(sb);
                }
            }
        }

        private static void SaveData<T>(Product product)
        {
            try
            {
                var result = MongoDBProvider.db.GetCollection<T>(typeof(T).Name).Save(product, SafeMode.True);
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }

        private static IQueryable<T> LoadData<T>()
        {
            try
            {
                return MongoDBProvider.db.GetCollection<T>(typeof(T).Name).AsQueryable();
            }
            catch (MongoConnectionException ex)
            {
                throw new MongoCommandException("Cannot access database. Please try again later");
            }
        }
    }
}
