using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure.CommandOrder
{
    public class CommandOrderRepository : BaseRepository, ICommandOrderRepository
    {
        #region Constructor

        public CommandOrderRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<CommandOrderModel> GetById(int id)
        {
            try
            {
                logger.Trace("CommandOrder_GetById_Entry");
                commandText = "USP_Donne_Command_OrdersById";
                List<CommandOrderModel> listCommandOrderModel = new List<CommandOrderModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CommandId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListCommandOrderModel(sqlDataReader, listCommandOrderModel);
                    }
                }
                logger.Trace("CommandOrder_GetById_Exit");
                return listCommandOrderModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("CommandOrder_GetById");
                string mensagem = "Erro ao consumir a controler CommandOrder, rota GetById " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task<IEnumerable<CommandOrderModel>> GetByIdAsync(int id)
        {
            try
            {
                logger.Trace("CommandOrder_GetByIdAsync_Entry");
                commandText = "USP_Donne_Command_OrdersById";
                List<CommandOrderModel> listCommandOrderModel = new List<CommandOrderModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CommandId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListCommandOrderModel(sqlDataReader, listCommandOrderModel);
                    }
                }
                logger.Trace("CommandOrder_GetByIdAsync_Exit");
                return listCommandOrderModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("CommandOrder_GetByIdAsync");
                string mensagem = "Erro ao consumir a controler CommandOrder, rota GetByIdAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private static void GetListCommandOrderModel(SqlDataReader sqlDataReader, List<CommandOrderModel> listCommandOrderModel)
        {
            CommandOrderModel commandOrderModel = new CommandOrderModel();
            GetCommandOrderModel(sqlDataReader, commandOrderModel);
            listCommandOrderModel.Add(commandOrderModel);
        }

        private static void GetCommandOrderModel(SqlDataReader sqlDataReader, CommandOrderModel commandOrderModel)
        {
            commandOrderModel.CommandId = Convert.ToInt32(sqlDataReader["CommandId"]);
            commandOrderModel.BuyerId = Convert.ToInt32(sqlDataReader["BuyerId"]);
            commandOrderModel.BuyerName = Convert.ToString(sqlDataReader["BuyerName"]);
            commandOrderModel.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
            commandOrderModel.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
            commandOrderModel.Amount = Convert.ToInt32(sqlDataReader["Amount"]);
            commandOrderModel.SalePrice = Convert.ToString(sqlDataReader["SalePrice"]);
            commandOrderModel.TotalSalePrice = Convert.ToString(sqlDataReader["TotalSalePrice"]);
        }

        #endregion
    }
}
