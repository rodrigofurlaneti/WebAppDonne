using System;
using System.Collections.Generic;

namespace Domain.Donne
{
    public class CategoryModel : BaseLog
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(int categoryId, string categoryName, List<DateTime> listDateTime, int userId, string userName) 
            : base(listDateTime, userId, userName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            DateInsert = listDateTime[0];
            DateUpdate = listDateTime[1];
            UserId = userId;
            UserName = userName;
        }
    }
}