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
        private static void GetListStockInventoryModel(SqlDataReader sqlDataReader, List<StockInventoryModel> listStockInventoryModel)
        {
            StockInventoryModel stockInventoryModel = new StockInventoryModel();
            GetStockInventoryModel(sqlDataReader, stockInventoryModel);
            listStockInventoryModel.Add(stockInventoryModel);
        }

        private static void GetStockInventoryModel(SqlDataReader sqlDataReader, StockInventoryModel stockInventoryModel)
        {
            stockInventoryModel.TotalValueCostOfInventory = Convert.ToString(sqlDataReader["TotalValueCostOfInventory"]);
            stockInventoryModel.TotalValueSaleStock = Convert.ToString(sqlDataReader["TotalValueSaleStock"]);
        }

        #endregion

    }
}
