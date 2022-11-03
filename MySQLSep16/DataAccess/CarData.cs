using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class CarData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();

        public List<CarModel> getAllCars()
        {
            string sql = "SELECT * FROM carmodels";
            List<CarModel> cars = _db.LoadData<CarModel, dynamic>(sql, new { });
            return cars;
        }

        public CarModel GetCarByID(int id)
        {
            string sql = "SELECT * FROM carmodels WHERE ModelID = @ModelID";
            List<CarModel> car = _db.LoadData<CarModel, dynamic>(sql, new { ModelID = id });
            return getAllCars().FirstOrDefault(u => u.ModelID == id);
        }

        public void CreateCar(CarModel c)
        {
            string sql = "INSERT INTO `carmodels` (`ModelName`, `ModelMPG`, `fuelCapacity`) VALUES (@ModelName, @ModelMPG, @fuelCapacity)";
            _db.SaveData(sql, c);
        }

        public void UpdateCar(CarModel c)
        {
            string sql = "UPDATE `carmodels` SET `ModelName` = @ModelName, 'ModelMPG' = @ModelMPG, 'fuelCapacity' = @fuelCapacity, 2023' WHERE `carmodels`.`ModelID` = ModelID";
            _db.SaveData(sql, c);
        }

        public void DeleteCar(CarModel c)
        {
            string sql = "DELETE FROM `carmodels` WHERE 'carmodels'.'ModelID' = @ModelID";
        }
    }
}
