namespace WebAppDonne.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public int CommandsId { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public int FormOfPaymentId { get; set; }
        public string FormOfPaymentName { get; set; }
        public string TotalValue { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
