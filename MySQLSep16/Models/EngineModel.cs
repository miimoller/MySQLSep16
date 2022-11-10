using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class EngineModel
    {
        public int EngineID { get; set; }
        public string EngineType { get; set; }
        public int FuelScaling { get; set; }
        public int Price { get; set; }
    }
}
