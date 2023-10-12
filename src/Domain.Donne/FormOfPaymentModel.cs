using System;

namespace Domain.Donne
{
    public class FormOfPaymentModel
    {
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

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
