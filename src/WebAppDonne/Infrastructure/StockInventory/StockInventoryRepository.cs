using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure.StockInventory
{
    public class StockInventoryRepository : BaseRepository, IStockInventoryRepository
    {
        #region Constructor

        public StockInventoryRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<StockInventoryModel> GetAll()
        {
            try
            {
                logger.Trace("StockInventory_GetAll_Entry");
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
                logger.Trace("StockInventory_GetAll_Exit");
                return listStockInventoryModel;
            }
            catch (Exception ex)
            {
                logger.TraceException("StockInventory_GetAll");
                string mensagem = "Erro ao consumir a controler StockInventory, rota GetAll " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task<IEnumerable<StockInventoryModel>> GetAllAsync()
        {
                try
                {
                    logger.Trace("StockInventory_GetAllAsync_Entry");
                    commandText = "USP_StockInventoryGetAll";
                    List<StockInventoryModel> listStockInventoryModel = new List<StockInventoryModel>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListStockInventoryModel(sqlDataReader, listStockInventoryModel);
                        }
                    }
                    logger.Trace("StockInventory_GetAllAsync_Exit");
                    return listStockInventoryModel;
                }
                catch (Exception ex)
                {
                    logger.TraceException("StockInventory_GetAllAsync");
                    string mensagem = "Erro ao consumir a controler StockInventory, rota GetAllAsync " + ex.Message;
                    throw new ArgumentNullException(mensagem);
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
