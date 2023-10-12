﻿using System;

namespace Domain.Donne
{
    public class BuyerModel
    {
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerPhone { get; set; }
        public string BuyerAddress { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }

        public BuyerModel()
        {
        }

        public BuyerModel(int buyerId, string buyerName, string buyerPhone, string buyerAddress, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName, bool status)
        {
            BuyerId = buyerId;
            BuyerName = buyerName;
            BuyerPhone = buyerPhone;
            BuyerAddress = buyerAddress;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
            Status = status;
        }
    }
}
