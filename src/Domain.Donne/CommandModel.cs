using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class CommandModel : BaseLog
    {
        public int CommandId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public bool Status { get; set; }

        public CommandModel()
        {
        }

        public CommandModel(int commandId, int buyerId, string buyerName, bool status, List<DateTime> listDateTime, 
            int userId, string userName) : base(listDateTime, userId, userName)
        {
            this.CommandId = commandId;
            this.BuyerId = buyerId;
            this.BuyerName = buyerName;
            this.DateInsert = listDateTime[0];
            this.DateUpdate = listDateTime[1];
            this.UserId = userId;
            this.UserName = userName;
            this.Status = status;
        }
    }
}
