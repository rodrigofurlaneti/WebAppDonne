namespace WebAppDonne.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public StoreModel Store { get; set; }
        public ProfileModel Profile { get; set; }
        public bool Status { get; set; }

        public UserModel(int userId, string userName, string userPassword, StoreModel store, ProfileModel profile, bool status)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
            Store = store;
            Profile = profile;
            Status = status;
        }

        public UserModel()
        {
        }
    }
    
}