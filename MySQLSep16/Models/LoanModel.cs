using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class LoanModel
    {
        public int UserID { get; set; }
        public double original_amount { get; set; }
        public double rate { get; set; }
        public int Term { get; set; }
        public double MonthlyPayment { get; set; }
                     
        public int LoanID { get; set; }
    }
}
