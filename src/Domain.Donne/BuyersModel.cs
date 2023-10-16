using System;

namespace Domain.Donne
{
    public class BuyerModel : BaseLog
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerAddress { get; set; }
        public bool Status { get; set; }

        public BuyerModel()
        {
        }

        public BuyerModel(int buyerId, string buyerName, string buyerPhone, string buyerAddress, bool status,
            DateTime dateInsert, DateTime dateUpdate, int userId, string userName) 
            : base(dateInsert, dateUpdate, userId, userName)
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
