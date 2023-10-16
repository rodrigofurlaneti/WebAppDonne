using System;
using System.Collections.Generic;

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

        public BaseLog(List<DateTime> listDateTime, int userId, string userName)
        {
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }

    
}
