namespace WebAppDonne.Models
{
    public class FormOfPaymentModel
    {
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
