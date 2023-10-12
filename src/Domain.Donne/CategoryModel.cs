using System;

namespace Domain.Donne
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime? DateInsert { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public CategoryModel()
        {
        }

        public CategoryModel(int categoryId, string categoryName, DateTime? dateInsert, DateTime? dateUpdate, int userId, string userName)
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