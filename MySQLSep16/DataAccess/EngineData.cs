using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class EngineData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();
        public List<EngineModel> getAllEngines()
        {
            string sql = "SELECT * FROM engines";

            List<EngineModel> engines = _db.LoadData<EngineModel, dynamic>(sql, new { });
            return engines;
        }

        public EngineModel GetEngineByID(int id)
        {
            string sql = "Select * FROM engines WHERE EngineID = @EngineID";
            List<EngineModel> engine = _db.LoadData<EngineModel, dynamic>(sql, new { EngineID = id });
            return engine.FirstOrDefault(u => u.EngineID == id);
        }

        public void CreateEngine(EngineModel e)
        {
            string sql = "INSERT INTO `engines` (`Name`, `FuelScaling`, 'Price') VALUES (@Name, @FuelScaling, @Price)";

            _db.SaveData(sql, e);
        }

        public void UpdateEngine(EngineModel e)
        {
            string sql = "UPDATE `engines` SET `Name` = @Name, `FuelScaling` = @FuelScaling, 'Price'=@Price WHERE `engines`.`EngineID` = @EngineID";
            _db.SaveData(sql, e);
        }

        public void DeleteEngine(EngineModel e)
        {
            string sql = "DELETE FROM engines WHERE `engines`.`EngineID` = @EngineID";
            _db.SaveData(sql, e);
        }
    }
}
