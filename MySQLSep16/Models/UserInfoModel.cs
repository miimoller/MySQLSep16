using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.Models
{
    internal class UserInfoModel
    {
        public int UserID { get; set; }
        public string email { get; set; }
        public string UserName { get; set; }
        public int SecurityQuestion { get; set; }
    }
}
