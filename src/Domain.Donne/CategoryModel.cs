using System;

namespace Domain.Donne
{
    public class CategoryModel : BaseLog
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(int categoryId, string categoryName, DateTime dateInsert, DateTime dateUpdate, int userId, string userName) 
            : base(dateInsert, dateUpdate, userId, userName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
            DateInsert = dateInsert;
            DateUpdate = dateUpdate;
            UserId = userId;
            UserName = userName;
        }
    }
}