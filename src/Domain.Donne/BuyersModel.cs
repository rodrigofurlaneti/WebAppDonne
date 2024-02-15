using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class BuyerModel : BaseLog
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerAddress { get; set; }
        public int Status { get; set; }

        public BuyerModel()
        {
        }

        public BuyerModel(int buyerId, string buyerName, string buyerPhone, string buyerAddress, int status,
            List<DateTime> listDateTime, int userId, string userName) 
            : base(listDateTime, userId, userName)
        {
            this.BuyerId = buyerId;
            this.BuyerName = buyerName;
            this.BuyerPhone = buyerPhone;
            this.BuyerAddress = buyerAddress;
            this.DateInsert = listDateTime[0];
            this.DateUpdate = listDateTime[1];
            this.UserId = userId;
            this.UserName = userName;
            this.Status = status;
        }
    }
}
