using Domain.Donne;
using System.Net;

namespace Business.Donne
{
    public class AuthenticationBusiness
    {
        public AuthenticationBusiness() { }

        public AuthenticationModel SimpleAuthenticationSuccess(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[6].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.RequestedCustomerName = "HostClient";
            authenticationModel.ClientInternetProtocol = "IpClient";
            authenticationModel.Authenticated = "1";
            authenticationModel.Status = "Success";
            return authenticationModel;
        }

        public AuthenticationModel SimpleAuthenticationInvalidPassword(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[6].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.RequestedCustomerName = "HostClient";
            authenticationModel.ClientInternetProtocol = "IpClient";
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid password";
            return authenticationModel;
        }

        public AuthenticationModel SimpleAuthenticationInvalidUserName(AuthenticationModel authenticationModel)
        {
            authenticationModel.HostedServerName = Dns.GetHostName();
            authenticationModel.ServerInternetProtocol = Dns.GetHostEntry(authenticationModel.HostedServerName).AddressList[6].ToString();
            authenticationModel.AuthenticationDateTime = DateTime.Now.ToString();
            authenticationModel.RequestedCustomerName = "HostClient";
            authenticationModel.ClientInternetProtocol = "IpClient";
            authenticationModel.Authenticated = "0";
            authenticationModel.Status = "Invalid user name";
            return authenticationModel;
        }
    }
}
