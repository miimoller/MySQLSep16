using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class CarModel
    {
        public int CarID { get; set; }
        public int Brand { get; set; }
        public int fgn_ModelID { get; set; }
        public int fgn_EngineID { get; set; }
        public int currentFuel { get; set; }
        public int sponsor { get; set; }
        public int userID { get; set; }
        public Boolean Finance { get; set; }
    }
}
