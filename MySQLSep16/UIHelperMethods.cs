using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16
{
    internal class UIHelperMethods
    {
        public static int checkForInt(string s)
        {
            
            int choice = -1;
            bool cont = false;
            while (!cont)
            {
                Console.WriteLine(s);
                cont = Int32.TryParse(Console.ReadLine(), out choice);
            }
            return choice;
        }
    }
}
