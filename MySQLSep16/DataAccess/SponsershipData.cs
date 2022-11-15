using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class SponsershipData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();

        public List<SponsershipModel> getAllSponsers()
        {
            string sql = "SELECT * FROM sponsorship";
            List<SponsershipModel> sponsers = _db.LoadData<SponsershipModel, dynamic>(sql, new { });
            return sponsers;
        }

        public SponsershipModel GetSponserByID(int id)
        {
            string sql = "SELECT * FROM sponsorship WHERE sponsorshipID = @sponsorshipID";
            List<SponsershipModel> sponsers = _db.LoadData<SponsershipModel, dynamic>(sql, new { sponsershipID = id });
            return sponsers[0];
        }
    }
}
