namespace WebAppDonne.Models
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
    }
}
