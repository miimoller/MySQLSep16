using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class ManufacturerModel
    {
        public int ManufacturerID { get; set; }
        public string ManufacturerName
        {
            get; set;
        }

            /* public override string ToString()
             {
                 string output = $"Sponsor Details\nSponsorship ID:{sponsorshipID}\nSponsorship Name:{SponsorName}\nSponsor Amount:{SponsorAmt}";
                 return output;
             }*/
        }
    }
