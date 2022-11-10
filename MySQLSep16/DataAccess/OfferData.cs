using MySQLSep16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLSep16.DataAccess
{
    internal class OfferData
    {
        private readonly ISqlDataAccess _db = new SqlDataAccess();
        public List<OfferModel> getAllOffers()
        {
            string sql = "SELECT * FROM offers";

            List<OfferModel> offers = _db.LoadData<OfferModel, dynamic>(sql, new { });
            return offers;
        }

        

        public OfferModel GetOfferByID(int id)
        {
            string sql = "Select * FROM offers WHERE OfferID = @OfferID";
            List<OfferModel> offer = _db.LoadData<OfferModel, dynamic>(sql, new { OfferID = id });
            return offer.FirstOrDefault(u => u.OfferID == id);
        }

        public void CreateOffer(OfferModel o)
        {
            string sql = "INSERT INTO `offers` (`BuyerID`, `SellerID`,`CarID`,`AskP`,`Accepted` ) VALUES (@BuyerID, @SellerID, @CarID, @AskP, @Accepted)";

            _db.SaveData(sql, o);
        }

        public void UpdateOffer(OfferModel o)
        {
            string sql = "UPDATE `offers` SET `BuyerID` = @BuyerID, `SellerID` = @SellerID, `CarID` = @SellerID, `AskP` = @AskP, `Accepted` = @Accepted WHERE `offers`.`OfferID` = @OfferID";
            _db.SaveData(sql, o);
        }

        public void DeleteOffer(OfferModel o)
        {
            string sql = "DELETE FROM offers WHERE `offers`.`OfferID` = @OfferID";
            _db.SaveData(sql, o);
        }
    }
}
