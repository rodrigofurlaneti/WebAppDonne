using System;

namespace Domain.Donne
{
    public class CompanyAssetModel : BaseLog
    {
        public int CompanyAssetId { get; set; }
        public string CompanyAssetName { get; set; }
        public string CostPrice { get; set; }
        public CompanyAssetModel()
        {
        }

        public CompanyAssetModel(int companyAssetId, string companyAssetName, string costPrice, DateTime dateInsert, 
            DateTime DateUpdate, int userId, string userName)
            : base()
        {
            this.CompanyAssetId = companyAssetId;
            this.CompanyAssetName = companyAssetName;
            this.CostPrice = costPrice;
            this.DateInsert = dateInsert;
            this.DateUpdate = DateUpdate;
            this.UserId = userId;
            this.UserName = userName;
        }

    }
}
