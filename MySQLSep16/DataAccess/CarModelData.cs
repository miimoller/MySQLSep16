using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class CarModelData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();

        public List<CarModelsModel> getAllCarModels()
        {
            string sql = "SELECT * FROM carmodels";
            List<CarModelsModel> cars = _db.LoadData<CarModelsModel, dynamic>(sql, new { });
            return cars;
        }

        public CarModelsModel GetCarByID(int id)
        {
            string sql = "SELECT * FROM carmodels WHERE ModelID = @ModelID";
            List<CarModelsModel> car = _db.LoadData<CarModelsModel, dynamic>(sql, new { ModelID = id });
            return getAllCarModels().FirstOrDefault(u => u.ModelID == id);
        }

        public void CreateCar(CarModelsModel c)
        {
            string sql = "INSERT INTO `carmodels` (`ModelName`, `ModelMPG`, `fuelCapacity`, 'Price') VALUES (@ModelName, @ModelMPG, @fuelCapacity, @Price)";
            _db.SaveData(sql, c);
        }

        public void UpdateCar(CarModelsModel c)//maybe a problem here
        {
            
            string sql = "UPDATE `carmodels` SET `ModelName` = @ModelName, `ModelMPG` = @ModelMPG, `fuelCapacity` = @fuelCapacity , `Price`=@Price WHERE `carmodels`.`ModelID` = @ModelID";
            _db.SaveData(sql, c);
        }

        public void DeleteCar(CarModelsModel c)
        {
            string sql = "DELETE FROM `carmodels` WHERE 'carmodels'.'ModelID' = @ModelID";
        }
    }
}
