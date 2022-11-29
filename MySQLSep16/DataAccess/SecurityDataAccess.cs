using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class SecurityDataAccess
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();

        public SecurityQuestionModel GetAnswersByUserID(int id)
        {
            string sql = "Select * FROM securityquestions WHERE UserID = @UserID";
            List<SecurityQuestionModel> answers = _db.LoadData<SecurityQuestionModel, dynamic>(sql, new { UserID = id });

            return answers.FirstOrDefault(u => u.UserID == id);
        }
        public void CreateAnswers(SecurityQuestionModel U)
        {
            string sql = "INSERT INTO `securityquestions` (`UserID`, `Question1`, `Question2`, `Question3`) VALUES (@UserID, @Question1, @Question2, @Question3);";
            _db.SaveData(sql, U);
        }
        public void DeleteAnswerByID(int UserID)
        {
            string sql = "DELETE FROM securityquestions WHERE `securityquestion`.UserID = @UserID";
            List<SecurityQuestionModel> users = _db.LoadData<SecurityQuestionModel, dynamic>(sql, new { UserID = UserID });
        }
        public void UpdateAnswers(SecurityQuestionModel U)
        {
            string sql = "Update `securityquestions` Set `UserID` = @UserID, `Question1` = @Question1, `Question2` = @Question2, `Question3` = @Question3 WHERE `securityquestion`.UserID ";
            _db.SaveData(sql, U);
        }
    }
}
