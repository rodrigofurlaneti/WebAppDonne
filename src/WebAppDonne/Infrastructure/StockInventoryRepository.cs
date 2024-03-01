using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class StockInventoryRepository : BaseRepository
    {
        #region Constructor

        public StockInventoryRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<StockInventoryModel> GetAllStockInventory()
        {
            commandText = "USP_StockInventoryGetAll";
            List<StockInventoryModel> listStockInventoryModel = new List<StockInventoryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListStockInventoryModel(sqlDataReader, listStockInventoryModel);
                }
            }
            logger.Trace("GetAllStockInventory");
            return listStockInventoryModel;
        }

        #endregion

        #region Helpers
        private void GetListStockInventoryModel(SqlDataReader sqlDataReader, List<StockInventoryModel> listStockInventoryModel)
        {
            StockInventoryModel stockInventoryModel = new StockInventoryModel();
            stockInventoryModel = GetStockInventoryModel(sqlDataReader, stockInventoryModel);
            listStockInventoryModel.Add(stockInventoryModel);
        }

        private StockInventoryModel GetStockInventoryModel(SqlDataReader sqlDataReader, StockInventoryModel stockInventoryModel)
        {
            stockInventoryModel.TotalValueCostOfInventory = Convert.ToString(sqlDataReader["TotalValueCostOfInventory"]);
            stockInventoryModel.TotalValueSaleStock = Convert.ToString(sqlDataReader["TotalValueSaleStock"]);
            return stockInventoryModel;
        }

        #endregion

    }
}
