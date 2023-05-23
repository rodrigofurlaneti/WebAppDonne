namespace WebAppDonne.Models
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
    }
}
