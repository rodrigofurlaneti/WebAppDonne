namespace WebAppDonne.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public bool Status { get; set; }

        public UserModel(int userId, string userName, string userPassword, int storeId, string storeName, int profileId, string profileName, bool status)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
            StoreId = storeId;
            StoreName = storeName;
            ProfileId = profileId;
            ProfileName = profileName;
            Status = status;
        }

        public UserModel()
        {
        }
    }

}