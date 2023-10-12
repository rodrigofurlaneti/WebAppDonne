using System;

namespace Domain.Donne
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public int CommandId { get; set; }
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentType { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public PaymentModel()
        {
        }

        public PaymentModel(int paymentId, int commandId, int formOfPaymentId, string formOfPaymentName, string paymentAmount, string paymentType, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName)
        {
            PaymentId = paymentId;
            CommandId = commandId;
            FormOfPaymentId = formOfPaymentId;
            FormOfPaymentName = formOfPaymentName;
            PaymentAmount = paymentAmount;
            PaymentType = paymentType;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }
}
