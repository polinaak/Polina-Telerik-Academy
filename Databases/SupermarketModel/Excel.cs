using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.Data.OleDb;
using System.Data;

namespace SupermarketModel
{
    public static class Excel
    {
        private const string ReportsDirectory = "Reports//";

        public static void LoadExcelReports(string directoryPath, string fileName)
        {
            ExtractZip(directoryPath, fileName);

            InputDataFromExl(directoryPath, "Test.xls");
        }

        private static void ExtractZip(string directoryPath, string fileName)
        {
            using (ZipFile zip = ZipFile.Read(directoryPath + fileName))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(directoryPath + ReportsDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
  
        private static void InputDataFromExl(string directoryPath, string excelFileName)
        {
            DataTable dt = new DataTable("newtable");
            OleDbConnectionStringBuilder csbuilder = new OleDbConnectionStringBuilder();
            csbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            csbuilder.DataSource = directoryPath + ReportsDirectory + excelFileName;
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

            Console.WriteLine(dt.Rows[0].ItemArray[0]);
            int rowsCount = dt.Rows.Count - 1;
            for (int i = 2; i < rowsCount; i++)
            {
                foreach (var item in dt.Rows[i].ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
