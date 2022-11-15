using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class TransactionDataAccess
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();

        public TransactionModel GetTransactionByID(int id)
        {
            string sql = "Select * FROM transactions WHERE transaction_ID = @transaction_ID";
            List<TransactionModel> account = _db.LoadData<TransactionModel, dynamic>(sql, new { transaction_ID = id });

            return account.FirstOrDefault(u => u.transaction_ID == id);
        }

        public List<TransactionModel> GetTransactionByUserID(int id)
        {
            string sql = "Select * FROM transactions WHERE 'UserID' = @UserID";
            List<TransactionModel> accounts = _db.LoadData<TransactionModel, dynamic>(sql, new { transaction_ID = id });

            return accounts;
        }

        public void UpdateTransaction(TransactionModel U)
        {
            string sql = "Update `transactions` Set `UserID` = @UserID, `Date` = @Date, `Amount` = @Amount, `Source` = @Source, `Type` = @Type WHERE `transactions`. transaction_ID = @transaction_ID ";
            _db.SaveData(sql, U);
        }

        public void DeleteTransactionByID(int transaction_ID)
        {
            string sql = "DELETE FROM transactions WHERE `transactions`.transaction_ID = @transaction_ID";
            List<TransactionModel> account = _db.LoadData<TransactionModel, dynamic>(sql, new { transaction_ID = transaction_ID });
        }

        public void CreateTransaction(TransactionModel U)
        {
            string sql = "INSERT INTO transactions (UserID, Date, Amount, Source, Type ) VALUES (@UserID, @Date, @Amount, @Source, @Type);";
            _db.SaveData(sql, U);
        }
    }
}
