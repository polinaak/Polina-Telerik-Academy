using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SupermarketModel
{
    public class ExpenseMongo
    {
        public ExpenseMongo(DateTime date, decimal sum, int vendorId)
        {
            this.Date = date;
            this.Sum = sum;
            this.VendorId = vendorId;
        }

        public ObjectId _id { get; set; }
        public DateTime Date { get; set; }
        public decimal Sum { get; set; }
        public int VendorId { get; set; }
    }
}
