using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class UserInfoData
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();

        public List<UserInfoModel> getAllUsers()
        {
            string sql = "SELECT * FROM userinfo";
            List<UserInfoModel> users = _db.LoadData<UserInfoModel, dynamic>(sql, new { });
            return users;
        }

        public UserInfoModel GetUserByID(int id)
        {
            string sql = "Select * FROM userinfo WHERE UserID = @UserID";
            List<UserInfoModel> users = _db.LoadData<UserInfoModel, dynamic>(sql, new { UserID = id });

            return users.FirstOrDefault(u => u.UserID == id);
        }


        public void CreateUser(UserInfoModel U)
        {
            string sql = "INSERT INTO `userinfo` (`Email`, `Username`, `SecurityQuestion`) VALUES (@Email, @Username, @SecurityQuestion);";
            _db.SaveData(sql, U);
        }
        public void DeleteUserByID(int UserID)
        {
            string sql = "DELETE FROM userinfo WHERE `userinfo`.UserID = @UserID";
            List<UserInfoModel> users = _db.LoadData<UserInfoModel, dynamic>(sql, new { UserID = UserID });
        }
        public void UpdateUser(UserInfoModel U)
        {
            //UPDATE `userinfo` SET `Email` = 'johncena6420@gmail.com', `Username` = 'YouCantSeeYou', `SecurityQuestion` = '2' WHERE `userinfo`.`UserID` = 1;
            string sql = "UPDATE `userinfo` SET `Email` = @Email, `Username` = @Username, `SecurityQuestion` = @SecurityQuestion WHERE `userinfo`. `UserID` = @UserID";
            _db.SaveData(sql, U);

        }
    }
}
