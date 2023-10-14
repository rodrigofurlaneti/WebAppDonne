using System;

namespace Domain.Donne
{
    public class FormOfPaymentModel : LogModel
    {
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }

        public FormOfPaymentModel()
        {
        }

        public FormOfPaymentModel(int formOfPaymentId, string formOfPaymentName, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName)
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
