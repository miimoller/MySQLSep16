using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class LoanDataAccess
    {
        private readonly SqlDataAccess _db = new SqlDataAccess();

        public List<LoanModel> getAllLoans()
        {
            string sql = "SELECT * FROM `loans`";
            List<LoanModel> loans = _db.LoadData<LoanModel, dynamic>(sql, new { });
            return loans;
        }

        public void CreateLoan(LoanModel L)
        {
            string sql = "INSERT INTO `loans`(`UserID`, `original_amount`, `rate`, `Term`, `MonthlyPayment`) VALUES (@UserID, @original_amount, @rate, @Term, @MonthlyPayment)";
            _db.SaveData(sql, L);
        }

        public void DeletebyLoanID(int LoanID)
        {
            string sql = "DELETE FROM `loans` WHERE LoanID = @LoanID";
            List<LoanModel> loans = _db.LoadData<LoanModel, dynamic>(sql, new { LoanID = LoanID });
        }

        //*Personally havent tested but jacob said works*

        public void UpdateLoan(LoanModel L)
        {
            string sql = "UPDATE `loans` SET `UserID`= @UserID,`original_amount`= @original_amount,`rate`= @rate,`Term`= @Term,`MonthlyPayment`= @MonthlyPayment WHERE `LoanID`= @LoanID";
            _db.SaveData(sql, L);
        }


        



        public LoanModel GetLoanByID(int ID)
        {
            string sql = "SELECT * FROM 'loans' WHERE LoanID = @LoanID";
            List<LoanModel> Loans = _db.LoadData<LoanModel, dynamic>(sql, new { UserID = ID });
            return Loans.FirstOrDefault(L => L.UserID == ID);
        }

        public List<LoanModel> GetLoansByUserID(int ID)
        {
            string sql = "SELECT * FROM 'loans' WHERE UserID = @UserID";
            List<LoanModel> Loans = _db.LoadData<LoanModel, dynamic>(sql, new { UserID = ID });
            return Loans;
        }

        public decimal CalculatePayment(double original_amount, int Term)
        {
            double p = original_amount;
            int n = Term;

            double a;

            double x = Math.Pow(1.003916, n);


            a = (p * (0.003916 * x)) / (x - 1);

            int total = (int)a;

            return total;




        }

    }
}
