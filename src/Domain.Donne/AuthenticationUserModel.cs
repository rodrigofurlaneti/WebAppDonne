namespace Domain.Donne
{
    public class AuthenticationUserModel
    {
        #region Properties

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public bool Status { get; set; }
        public int Id { get; set; }
        public string HostedServerName { get; set; }
        public string ServerInternetProtocol { get; set; }
        public string AuthenticationDateTime { get; set; }
        public string NavigatorUserAgent { get; set; }
        public string ClientInternetProtocol { get; set; }
        public string Authenticated { get; set; }
        public string AuthenticationStatus { get; set; }

        #endregion

        #region Constructor

        public AuthenticationUserModel() { }

        #endregion
    }
}
