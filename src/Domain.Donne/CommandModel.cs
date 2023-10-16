using System;

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

        public CommandModel(int commandId, int buyerId, string buyerName, bool status,DateTime dateInsert, 
            DateTime dateUpdate, int userId, string userName) : base(dateInsert, 
                dateUpdate, userId, userName)
        {
            this.CommandId = commandId;
            this.BuyerId = buyerId;
            this.BuyerName = buyerName;
            this.DateInsert = dateInsert;
            this.DateUpdate = dateUpdate;
            this.UserId = userId;
            this.UserName = userName;
            this.Status = status;
        }
    }
}
