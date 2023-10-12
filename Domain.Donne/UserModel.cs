namespace Domain.Donne
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public bool Status { get; set; }

        public UserModel(int userId, string userName, string userPassword, int profileId, string profileName, bool status)
        {
            UserId = userId;
            UserName = userName;
            UserPassword = userPassword;
            ProfileId = profileId;
            ProfileName = profileName;
            Status = status;
        }

        public UserModel()
        {
        }
    }

}