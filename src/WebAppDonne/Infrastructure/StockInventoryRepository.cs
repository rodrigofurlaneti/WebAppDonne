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

        public async Task<IEnumerable<StockInventoryModel>> GetAllStockInventory()
        {
            commandText = "USP_StockInventoryGetAll";
            List<StockInventoryModel> listStockInventoryModel = new List<StockInventoryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListStockInventoryModel(sqlDataReader, listStockInventoryModel);
                    }
                    logger.Trace("StockInventory_GetAllAsync");
                    return listStockInventoryModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler StockInventory, rota GetAllAsync " + ex.Message;
                    logger.TraceException("StockInventory_GetAllAsync");
                    throw new ArgumentNullException(mensagem);
                }
            }
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
