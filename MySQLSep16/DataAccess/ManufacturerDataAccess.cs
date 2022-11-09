using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class ManufacturerDataAccess
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();
        public List<ManufacturerModel> getAllManufacturer()
        {
            string sql = "SELECT * FROM manufacturer";

            List<ManufacturerModel> manufacturers = _db.LoadData<ManufacturerModel, dynamic>(sql, new { });
            return manufacturers;
        }

        public ManufacturerModel GetManufacturerByID(int id)
        {
            string sql = "Select * FROM manufacturer WHERE ManufacturerID = @ManufacturerID";
            List<ManufacturerModel> manufacturer = _db.LoadData<ManufacturerModel, dynamic>(sql, new { ManufacturerID = id });
            return manufacturer.FirstOrDefault(u => u.ManufacturerID == id);
        }

        public void CreateManufacturer(ManufacturerModel e)
        {
            string sql = "INSERT INTO `manufacturers` (ManufacturerName) VALUES (@ManufacturerName)";

            _db.SaveData(sql, e);
        }

        public void UpdateManufacturer(ManufacturerModel e)
        {
            string sql = "UPDATE `Manufacturer` SET `ManufacturerName` = @ManufacturerName WHERE `manufacturer`.`ManufacturerID` = @ManufacturerID";
            _db.SaveData(sql, e);
        }

        public void DeleteManufacturer(ManufacturerModel e)
        {
            string sql = "DELETE FROM Manufacturer WHERE `Manufacturer`.`ManufacturerID` = @ManufacturerID";
            _db.SaveData(sql, e);
        }
    }
}
