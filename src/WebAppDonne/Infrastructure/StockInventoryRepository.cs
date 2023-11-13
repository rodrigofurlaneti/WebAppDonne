using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class StockInventoryRepository : BaseRepository
    {
        #region Constructor

        public StockInventoryRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<StockInventoryModel> GetAllStockInventory()
        {
            List<StockInventoryModel> listStockInventoryModel = new List<StockInventoryModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_StockInventoryGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StockInventoryModel stockInventory = new StockInventoryModel();
                    stockInventory.TotalValueCostOfInventory = Convert.ToString(rdr["TotalValueCostOfInventory"]);
                    stockInventory.TotalValueSaleStock = Convert.ToString(rdr["TotalValueSaleStock"]);
                    listStockInventoryModel.Add(stockInventory);
                }
            }
            logger.Trace("GetAllStockInventory");
            return listStockInventoryModel;
        }

        #endregion

    }
}
