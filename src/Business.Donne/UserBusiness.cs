﻿using Domain.Donne;

namespace Business.Donne
{
    public class UserBusiness
    {
        public UserBusiness() { }

        public bool SimpleAuthentication(UserModel userModelRequest, UserModel userModelBd)
        {
            if (userModelRequest.UserPassword.Equals(userModelBd.UserPassword))
                return true;
            return false;
        }
    }
}
