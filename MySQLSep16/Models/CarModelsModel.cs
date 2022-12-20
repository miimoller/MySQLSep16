using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class CarModelsModel
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public float ModelMPG { get; set; }
        public float fuelCapacity { get; set; }
        public int Price { get; set; }

        public int basePrice { get; set; }
    }
}
