using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16
{
    internal class GameSpace
    {
       
        public enum space { empty, gas, sponserM, sponserC, sponserH, sponserS, sponserT, car, person, userCar, boarder}
        public char symbol { get; set; }
        public space symbolType { get; set; }
    }
}
