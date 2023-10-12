using System;

namespace Domain.Donne
{
    public class ProfileModel
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
