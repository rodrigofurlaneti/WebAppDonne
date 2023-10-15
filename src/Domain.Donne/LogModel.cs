using System;

namespace Domain.Donne
{
    public class LogModel
    {
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public LogModel()
        {
            
        }

        public LogModel(DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName)
        {
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }

    
}
