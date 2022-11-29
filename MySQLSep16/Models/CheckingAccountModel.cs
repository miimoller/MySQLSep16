using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class CheckingAccountModel
    {
        public int AccountID { get; set; }
        public double CurrentBalence { get; set; }
        public double Loans { get; set; }
        public int UserID { get; set; }
    }
}
