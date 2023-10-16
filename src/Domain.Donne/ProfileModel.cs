using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class ProfileModel : BaseLog
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }

        public ProfileModel()
        {
        }

        public ProfileModel(int profileId, string profileName, List<DateTime> listDateTime, int userId, string userName)
        {
            ProfileId = profileId;
            ProfileName = profileName;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }
}
