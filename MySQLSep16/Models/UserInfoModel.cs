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
        public string Email { get; set; }
        public string Username { get; set; }
        public int SecurityQuestion { get; set; }
    }
}
