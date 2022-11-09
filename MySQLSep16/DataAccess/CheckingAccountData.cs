using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class CheckingAccountData
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();
        public void CreateAccount(CheckingAccountModel c)
        {
            string sql = "INSERT INTO `checkingaccount` (`AccountID`, `CurrentBalance`, `Loans`) VALUES (@AccountID, @CurrentBalance, @Loans)";
            _db.SaveData(sql, c);
        }
        public List<CheckingAccountModel> getAllAccounts()
        {
            string sql = "SELECT * FROM checkingaccount";
            List<CheckingAccountModel> accounts = _db.LoadData<CheckingAccountModel, dynamic>(sql, new { });
            return accounts;
        }
        public void DeleteAccountByID(int AccountID)
        {
            string sql = "DELETE FROM `checkingaccount` WHERE AccountID = @AccountID";
            List<CheckingAccountModel> Accounts = _db.LoadData<CheckingAccountModel, dynamic>(sql, new { AccountID = AccountID });
        }
        public void UpdateAccount(CheckingAccountModel U)
        {
            string sql = "UPDATE `checkingaccount` SET `AccountID`= @AccountID,`CurrentBalance`= @CurrentBalance,`Loans`=@Loans WHERE 1";
            _db.SaveData(sql, U);
        }
        public CheckingAccountModel GetAccountByID(int id)
        {
            string sql = "SELECT * FROM `checkingaccount` WHERE AccountID = @AccountID";
            List<CheckingAccountModel> Users = _db.LoadData<CheckingAccountModel, dynamic>(sql, new { AccountID = id });
            return Users.FirstOrDefault(u => u.AccountID == id);
        }
    }
}
