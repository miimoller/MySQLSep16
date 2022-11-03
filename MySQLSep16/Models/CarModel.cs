using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class CarModel
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public double ModelMPG { get; set; }
        public double fuelCapacity { get; set; }
    }
}
