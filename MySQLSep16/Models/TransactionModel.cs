using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class TransactionModel
    {
        public int UserID { get; set; }
        public int transaction_ID { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Source { get; set; }
        public Boolean Type { get; set; }//0= deposit 1=withdrawal
    }
}
