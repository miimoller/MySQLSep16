using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class SqlDataAccess
    {
        private string connectionString = "server=localhost;port=3306;uid=appDev;pwd=AppDev;database=db_garage;";

        public List<T> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {

            }
        }
    }
}
