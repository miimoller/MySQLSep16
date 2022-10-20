using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class OfferModel
    {
        public int OfferID { get; set; }
        public int BuyerID { get; set; }
        public int SellerID { get; set; }
        public int CarID { get; set; }
        public int AskP { get; set; }
        public bool Accepted { get; set; }

    }
}
