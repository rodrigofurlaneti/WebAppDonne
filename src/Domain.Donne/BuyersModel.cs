using System;

namespace Domain.Donne
{
    public class BuyerModel : LogModel
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerAddress { get; set; }
        public bool Status { get; set; }

        public BuyerModel()
        {
        }

        public BuyerModel(int buyerId, string buyerName, string buyerPhone, string buyerAddress, DateTime dateInsert, DateTime dateUpdate, int userId, string userName, bool status)
        {
            this.BuyerId = buyerId;
            this.BuyerName = buyerName;
            this.BuyerPhone = buyerPhone;
            this.BuyerAddress = buyerAddress;
            this.DateInsert = dateInsert;
            this.DateUpdate = dateUpdate;
            this.UserId = userId;
            this.UserName = userName;
            this.Status = status;
        }
    }
}
