using System.Linq;
using SupermarketMySqlModel;

namespace SupermarketModel
{
    public static class MySqlUtils
    {
        public static void LoadMySqlData()
        {
            using (var mySqlContext = new SupermarketMySqlContext())
            {
                using (var sqlServerContext = new SupermarketContext())
                {
                    foreach (var measure in mySqlContext.Measures)
                    {
                        var measures = sqlServerContext.Measures.Where(x => x.Name == measure.Name);
                        if (measures.Count() == 0)
                        {
                            var sqlServerMesure = new SupermarketModel.Measure
                            {
                                Name = measure.Name
                            };

                            sqlServerContext.Measures.Add(sqlServerMesure);
                        }
                    }

                    sqlServerContext.SaveChanges();

                    foreach (var vendor in mySqlContext.Vendors)
                    {
                        var vendors = sqlServerContext.Vendors.Where(x => x.Name == vendor.Name);
                        if (vendors.Count() == 0)
                        {
                            var sqlServerVendor = new SupermarketModel.Vendor
                            {
                                Name = vendor.Name
                            };

                            sqlServerContext.Vendors.Add(sqlServerVendor);
                        }
                    }

                    sqlServerContext.SaveChanges();

                    foreach (var product in mySqlContext.Products)
                    {
                        var products = sqlServerContext.Products
                            .Where(x => x.Name == product.Name &&
                            x.Price == product.BasePrice &&
                            x.VendorId == product.VendorsId);
                        if (products.Count() == 0)
                        {
                            var sqlServerProduct = new SupermarketModel.Product
                            {
                                Name = product.Name,
                                MesureId = product.MeasuresId,
                                Price = product.BasePrice,
                                VendorId = product.VendorsId
                            };

                            sqlServerContext.Products.Add(sqlServerProduct);
                        }
                    }

                    sqlServerContext.SaveChanges();
                }
            }
        }
    }
}
