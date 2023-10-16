using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class FormOfPaymentModel : BaseLog
    {
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }

        public FormOfPaymentModel()
        {
        }

        public FormOfPaymentModel(int formOfPaymentId, string formOfPaymentName, List<DateTime> listDateTime,
            int userId, string userName) : base(listDateTime, userId, userName)
        {
            FormOfPaymentId = formOfPaymentId;
            FormOfPaymentName = formOfPaymentName;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }
}
