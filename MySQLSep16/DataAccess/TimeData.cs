using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class TimeData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();
        public void UpdateTime(TimeModel c, int a)
        {
            string sql = $"UPDATE `time` SET `TimePassed` = {a} WHERE `time`.`UserID` = @UserID";
            _db.SaveData(sql, c);
        }

        public TimeModel GetTimeByID(int id)
        {
            string sql = "SELECT * FROM time WHERE UserID = @UserID";
            List<TimeModel> time = _db.LoadData<TimeModel, dynamic>(sql, new { UserID=id});
            return time[0];

        }

        public void CreateTime(TimeModel c)
        {
            string sql = "INSERT INTO time (UserID, TimePassed) VALUES (@UserID, @TimePassed)";

            _db.SaveData(sql, c);

        }
    }
}
