namespace Domain.Donne
{
    public class AuthenticationModel
    {
        #region Properties

        public int Id { get; set; }
        public string HostedServerName { get; set; }
        public string ServerInternetProtocol { get; set; }
        public string AuthenticationDateTime { get; set; }
        public string RequestedCustomerName { get; set; }
        public string ClientInternetProtocol { get; set; }
        public string Authenticated { get; set; }
        public string Status { get; set; }

        #endregion

        #region Constructor

        public AuthenticationModel() { }

        #endregion
    }
}
