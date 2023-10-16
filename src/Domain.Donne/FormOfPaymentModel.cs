using System;

namespace Domain.Donne
{
    public class FormOfPaymentModel : BaseLog
    {
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }

        public FormOfPaymentModel()
        {
        }

        public FormOfPaymentModel(int formOfPaymentId, string formOfPaymentName, DateTime dateInsert, 
            DateTime dateUpdate, int userId, string userName) : base(dateInsert, dateUpdate, userId, userName)
        {
            FormOfPaymentId = formOfPaymentId;
            FormOfPaymentName = formOfPaymentName;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }
}
