using System;

namespace Domain.Donne
{
    public class CommandModel
    {
        public int CommandId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }

        public CommandModel()
        {
        }

        public CommandModel(int commandId, int buyerId, string buyerName, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName, bool status)
        {
            CommandId = commandId;
            BuyerId = buyerId;
            BuyerName = buyerName;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
            Status = status;
        }
    }
}
