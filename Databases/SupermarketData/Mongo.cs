using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using SupermarketModel;

namespace SupermarketData
{
    public static class Mongo
    {
        public static void Export()
        {
            using (SupermarketContext context = new SupermarketContext())
            {
                if (Directory.Exists("..//..//..//Resources//JsonReports"))
                {
                    Directory.Delete("..//..//..//Resources//JsonReports", true);
                }

                Directory.CreateDirectory("..//..//..//Resources//JsonReports");

                var query = context.Reports.OrderBy(x => x.Id).ToList();
                var connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var server = client.GetServer();
                var mongoDB = server.GetDatabase("test");
                mongoDB.DropCollection("ProductReports");
                var collection = mongoDB.GetCollection("ProductReports");
                StringBuilder jsonSb = new StringBuilder();

                bool firstId = true;
                int tmpId = 0;
                int totalQuantity = 0;
                decimal totalIncome = 0;
                string productName = string.Empty;
                string vendorName = string.Empty;
                foreach (var item in query)
                {
                    if (firstId)
                    {
                        tmpId = item.Id;
                        firstId = false;
                    }

                    if (tmpId == item.Id)
                    {
                        totalIncome += item.Sum;
                        totalQuantity += item.Quantity;
                        productName = item.Product.Name;
                        vendorName = item.Product.Vendor.Name;
                    }
                    else
                    {
                        jsonSb.Clear();

                        jsonSb.AppendLine("{");
                        jsonSb.AppendLine(string.Format("    \"product-id\" : {0},", tmpId));
                        jsonSb.AppendLine(string.Format("    \"product-name\" : \"{0}\",", productName));
                        jsonSb.AppendLine(string.Format("    \"vendor-name\" : \"{0}\",", vendorName));
                        jsonSb.AppendLine(string.Format("    \"total-quantity-sold\" : {0},", totalQuantity));
                        jsonSb.AppendLine(string.Format("    \"total-incomes\" : {0},", totalIncome.ToString("F2", CultureInfo.CreateSpecificCulture("en-US"))));
                        jsonSb.AppendLine("}");


                        using (StreamWriter file = new StreamWriter(string.Format("../../../Product-Reports/{0}.json", tmpId), false))
                        {
                            file.WriteLine(jsonSb.ToString());
                        }

                        totalIncome = item.Sum;
                        totalQuantity = item.Quantity;
                        tmpId = item.Id;

                        collection.Save(BsonDocument.Parse(jsonSb.ToString()));
                    }
                }

                jsonSb.Clear();

                jsonSb.AppendLine("{");
                jsonSb.AppendLine(string.Format("    \"product-id\" : {0},", tmpId));
                jsonSb.AppendLine(string.Format("    \"product-name\" : \"{0}\",", productName));
                jsonSb.AppendLine(string.Format("    \"vendor-name\" : \"{0}\",", vendorName));
                jsonSb.AppendLine(string.Format("    \"total-quantity-sold\" : {0},", totalQuantity));
                jsonSb.AppendLine(string.Format("    \"total-incomes\" : {0},", totalIncome.ToString("F2", CultureInfo.CreateSpecificCulture("en-US"))));
                jsonSb.AppendLine("}");

                collection.Save(BsonDocument.Parse(jsonSb.ToString()));

                using (StreamWriter file = new StreamWriter(string.Format("../../../Product-Reports/{0}.json", tmpId), false))
                {
                    file.WriteLine(jsonSb.ToString());
                }
            }
        }
    }
}
