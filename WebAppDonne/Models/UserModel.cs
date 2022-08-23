namespace WebAppDonne.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public bool Status { get; set; }
    }
}