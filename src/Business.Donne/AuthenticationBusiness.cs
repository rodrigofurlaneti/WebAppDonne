using Domain.Donne;
using System.Net;

namespace Business.Donne
{
    public class AuthenticationBusiness
    {
        protected AuthenticationBusiness() { }

        public static void SimpleAuthenticationSuccess(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "1";
            authenticationModel.Status = "Success";

            if (Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList.Length == 3)
                authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();
        }

        public static AuthenticationModel SimpleAuthenticationInvalidPassword(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid password";

            if (Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList.Length == 3)
                authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();

            return authenticationModel;
        }

        public static AuthenticationModel SimpleAuthenticationInvalidUserName(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid user name";

            if (Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList.Length == 3)
                authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[3].ToString();

            return authenticationModel;
        }
    }
}
