using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class PwdDataAccess
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();

        public NotPwdModel GetPasswordByID(int id)
        {
            string sql = "Select * FROM notpwd WHERE UserID = @UserID";
            List<NotPwdModel> password = _db.LoadData<NotPwdModel, dynamic>(sql, new { UserID = id });

            return password[0];
        }

        public void UpdatePwd(NotPwdModel U)
        {
            string sql = "Update `notpwd` Set `UserID` = @UserID, `Pwd` = @Pwd WHERE `notpwd`.";
            _db.SaveData(sql, U);
        }

        public void DeletePwdByID(int UserID)
        {
            string sql = "DELETE FROM notpwd WHERE `notpwd`.UserID = @UserID";
            List<NotPwdModel> password = _db.LoadData<NotPwdModel, dynamic>(sql, new { UserID = UserID });
        }

        public void CreatePwd(NotPwdModel U)
        {
            string sql = "INSERT INTO notpwd (UserID, Pwd) VALUES (@UserID, @Pwd);";
            _db.SaveData(sql, U);
        }
    }
}
