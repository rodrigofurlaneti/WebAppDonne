using System;

namespace Domain.Donne
{
    public class BaseLog
    {
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public BaseLog()
        {
            
        }

        public BaseLog(DateTime dateInsert, DateTime dateUpdate, int userId, string userName)
        {
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }

    
}
