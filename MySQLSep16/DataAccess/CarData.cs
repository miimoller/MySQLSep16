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
            string sql = "SELECT * FROM car";
            List<CarModel> cars = _db.LoadData<CarModel, dynamic>(sql, new { });
            return cars;
        }

        public CarModel GetCarByID(int id)
        {
            string sql = "SELECT * FROM car WHERE CarID = @CarID";
            List<CarModel> car = _db.LoadData<CarModel, dynamic>(sql, new { CarID = id });
            return getAllCars().FirstOrDefault(u => u.CarID == id);
        }

        public List<CarModel> GetCarsByUserID(int userID)
        {
            string sql = "SELECT * FROM car WHERE UserID = @UserID";
            List<CarModel> cars = _db.LoadData<CarModel, dynamic>(sql, new { userID = userID });
            return cars;
        }

        public void CreateCar(CarModel c)//fix this too
        {
            string sql = "INSERT INTO `car` (`Brand`, `fgn_ModelID`, `fgn_EngineID`, `currentFuel`, `sponsor`, `userID`, `Finance`) VALUES (@Brand, @fgn_ModelID, @fgn_EngineID, @currentFuel, @sponsor, @userID, @Finance )";
            _db.SaveData(sql, c);
        }

        public void UpdateCar(CarModel c)
        {
            string sql = "UPDATE `car` SET `CarID` = @CarID, `Brand` = @Brand, `fgn_ModelID` = @fgn_ModelID, `fgn_EngineID` = @fgn_EngineID, `currentFuel` = @currentFuel, `sponsor` = @sponsor, `userID` = @userID, `Finance` = @Finance WHERE `car`.`CarID` = @CarID;";
            _db.SaveData(sql, c);
        }

        public void DeleteCar(CarModel c)
        {
            string sql = "DELETE FROM `car` WHERE 'car'.'CarID' = @CarID";
            _db.SaveData(sql, c);
        }
    }
}
