using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketModel;
using SupermarketMySqlModel;

namespace SupermarketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlUtils.LoadMySqlData();
            ExcelUtils.LoadExcelReports("../../../Resources/", "Sales-Reports.zip");
            PdfCreator.GeneratePdf();
            XmlUtils.GenerateSalesReport();
            XmlUtils.LoadExpensesIntoDatabases("../../../Resources/Vendors-Expenses.xml");
        }
    }
}
