using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class BankData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();

        public List<BankModel> getAllTx()
        {
            string sql = "SELECT * FROM tx_history";
            return _db.LoadData<BankModel, dynamic>(sql, new { });
        }

        public BankModel getTxByID(int id)
        {
            string sql= "Select * FROM tx_history WHERE txID = @txID";
            return _db.LoadData<BankModel, dynamic>(sql, new { txID=id})[0];
        }

        public void CreateTx(BankModel b)
        {
            string sql = "INSERT INTO `tx_history` (`Amt`, `txDate`, `tx_type_typeID`) VALUES (@Amt, @txDate, @tx_type_typeID)";

            _db.SaveData(sql, b);
        }

        public void UpdateTx(BankModel b)
        {
            string sql = "UPDATE `tx_history` SET `Amt` = @Amt, `txDate` = @txDate, `tx_type_typeID` = @tx_type_typeID WHERE `tx_history`.`txID` = @txID";
            _db.SaveData(sql, b);
        }

        public void deleteTx(BankModel b)
        {
            string sql = "DELETE FROM tx_history WHERE `tx_history`.`txID` = @txID";
            _db.SaveData(sql, b);
        }
        

        }

    }

