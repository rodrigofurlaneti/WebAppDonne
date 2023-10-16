using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class PaymentModel : BaseLog
    {
        public int PaymentId { get; set; }
        public int CommandId { get; set; }
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }
        public string PaymentAmount { get; set; }
        public string PaymentType { get; set; }

        public PaymentModel()
        {
        }

        public PaymentModel(int paymentId, int commandId, int formOfPaymentId, string formOfPaymentName,
            string paymentAmount, string paymentType, List<DateTime> listDateTime, int userId, 
            string userName) : base(listDateTime, userId, userName)
        {
            PaymentId = paymentId;
            CommandId = commandId;
            FormOfPaymentId = formOfPaymentId;
            FormOfPaymentName = formOfPaymentName;
            PaymentAmount = paymentAmount;
            PaymentType = paymentType;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }
}
