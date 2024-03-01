using Domain.Donne;
using System.Net;

namespace Business.Donne
{
    public class AuthenticationBusiness
    {
        protected AuthenticationBusiness() { }

        public static AuthenticationModel SimpleAuthenticationSuccess(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "1";
            authenticationModel.Status = "Success";
            return authenticationModel;
        }

        public static AuthenticationModel SimpleAuthenticationInvalidPassword(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid password";
            return authenticationModel;
        }

        public static AuthenticationModel SimpleAuthenticationInvalidUserName(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid user name";
            return authenticationModel;
        }
    }
}
