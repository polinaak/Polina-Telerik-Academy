using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using Ionic.Zip;

namespace SupermarketModel
{
    public static class ExcelUtils
    {
        private const string ReportsDirectory = "Reports/";
        private const string FileExtension = "*.xls";

        public static void LoadExcelReports(string directoryPath, string fileName)
        {
            ExtractZip(directoryPath, fileName);
            TraversDirectories(string.Format("{0}{1}", directoryPath, ReportsDirectory));
        }

        private static void ExtractZip(string directoryPath, string fileName)
        {
            using (ZipFile zip = ZipFile.Read(string.Format("{0}{1}", directoryPath, fileName)))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(string.Format("{0}{1}", directoryPath, ReportsDirectory), ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        private static void TraversDirectories(string rootDirectory)
        {
            var innerDirectories = Directory.GetDirectories(rootDirectory);
            foreach (var directory in innerDirectories)
            {
                var files = Directory.GetFiles(directory, FileExtension);
                foreach (var file in files)
                {
                    string dateString = directory.Substring(directory.LastIndexOf('/') + 1);
                    InsertDataFromXls(file, dateString);
                }
            }

            try
            {
                Directory.Delete(rootDirectory, true);
            }
            catch (Exception)
            {
                // Like a pro!
            }
        }

        private static void InsertDataFromXls(string filePath, string dateString)
        {
            DataTable dt = new DataTable("newtable");
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = filePath;
            csbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            using (OleDbConnection connection = new OleDbConnection(csbuilder.ConnectionString))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sales$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }

                connection.Close();
            }

            string[] dateParts = dateString.Split('-');
            int day = int.Parse(dateParts[0]);
            int month = GetMonthAsInt(dateParts[1]);
            int year = int.Parse(dateParts[2]);
            DateTime reportDate = new DateTime(year, month, day);

            int rowsCount = dt.Rows.Count - 1;
            for (int i = 2; i < rowsCount; i++)
            {
                Report report = new Report
                {
                    ProductId = Convert.ToInt32(dt.Rows[i].ItemArray[0]),
                    Quantity = Convert.ToInt32(dt.Rows[i].ItemArray[1]),
                    UnitPrice = Convert.ToDecimal(dt.Rows[i].ItemArray[2]),
                    Sum = Convert.ToDecimal(dt.Rows[i].ItemArray[3]),
                    Date = reportDate
                };

                string locationName = dt.Rows[0].ItemArray[0].ToString();
                InsertInSqlServer(report, locationName);
            }
        }

        private static void InsertInSqlServer(Report report, string locationName)
        {
            using (var context = new SupermarketContext())
            {
                var reports = context.Reports
                                     .Where(x => x.Date == report.Date &&
                                                 x.Location.Name == locationName &&
                                                 x.ProductId == report.ProductId);
                if (reports.Count() > 0)
                {
                    return;
                }

                var locations = context.Locations.Where(x => x.Name == locationName);
                if (locations.Count() > 0)
                {
                    report.Location = locations.First();
                }
                else
                {
                    report.Location = new Location { Name = locationName };
                }

                context.Reports.Add(report);
                context.SaveChanges();
            }
        }

        private static int GetMonthAsInt(string month)
        {
            switch (month)
            {
                case "Jan":
                    return 1;
                case "Feb":
                    return 2;
                case "Mar":
                    return 3;
                case "Apr":
                    return 4;
                case "May":
                    return 5;
                case "Jun":
                    return 6;
                case "Jul":
                    return 7;
                case "Aug":
                    return 8;
                case "Sep":
                    return 9;
                case "Oct":
                    return 10;
                case "Nov":
                    return 11;
                case "Dec":
                    return 12;
                default:
                    throw new ArgumentException(string.Format("Incorrect month {0}", month));
            }
        }
    }
}