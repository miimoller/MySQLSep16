using MySql.Data.MySqlClient;
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
        private readonly ISqlDataAccess _db=new SqlDataAccess();

        public List<CarModel> getAllCars()
        {
            string sql = "SELECT * FROM car_basic";

            List<CarModel> cars = _db.LoadData<CarModel, dynamic>(sql, new { });
;           return cars;
        }

        public void CreateCar(CarModel c)
        {
            string sql = "INSERT INTO `car_basic` (`Year`, `Make`, `Model`) VALUES (@Year, @Make, @Model)";

            _db.SaveData(sql, c);
        }

        public List<CarModel> SearchYear()
        {
            string sql = "SELECT * FROM car_basic WHERE Year=2022";

            List<CarModel> cars = _db.LoadData<CarModel, dynamic>(sql, new { });
            return cars;
        }


        public List<int> getYears()
        {
            string sql = "SELECT DISTINCT Year FROM car_basic";

            List<int> years = _db.LoadData<int, dynamic>(sql, new { });
            return years;
        }
        public List<string> getModels()
        {
            string sql = "SELECT DISTINCT Model FROM car_basic";

            List<string> models = _db.LoadData<string, dynamic>(sql, new { });
            return models;
        }

        public List<string> getMake()
        {
            string sql = "SELECT DISTINCT Make FROM car_basic";

            List<string> make = _db.LoadData<string, dynamic>(sql, new { });
            return make;
        }
        /*
        private string connectionstring = "server=localhost;port=3306;uid=appDev;pwd=AppDev;database=db_garage;";

        public List<CarModel> getAllCars()
        {
            List<CarModel> cars = new List<CarModel>();

            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM car_basic",connection);

            using (MySqlDataReader reader= command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CarModel car = new CarModel
                    {
                        CarID = reader.GetInt32(0),
                        Year = reader.GetInt32(1),
                        Make = reader.GetString(2),
                        Model = reader.GetString(3)
                    };
                    cars.Add(car);
                }
            }


            return cars;
        }
        */
    }
}
