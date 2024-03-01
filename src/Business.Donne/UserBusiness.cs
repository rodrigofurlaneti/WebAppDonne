using Domain.Donne;

namespace Business.Donne
{
    public static class UserBusiness
    {
        public static bool SimpleAuthentication(AuthenticationUserModel userModelRequest, UserModel userModelBd)
        {
            if (userModelRequest.UserPassword.Equals(userModelBd.UserPassword))
                return true;
            return false;
        }
    }
}
