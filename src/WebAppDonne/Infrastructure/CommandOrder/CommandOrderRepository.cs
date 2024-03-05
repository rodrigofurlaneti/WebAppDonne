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
            logger.Trace("GetCommandOrder");
            return listCommandOrderModel;
        }

        public async Task<IEnumerable<CommandOrderModel>> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_Command_OrdersById";
            List<CommandOrderModel> listCommandOrderModel = new List<CommandOrderModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
                try
                {
                    SqlCommand cmd = new SqlCommand(commandText, con);
                    cmd.Parameters.AddWithValue("@CommandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await cmd.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListCommandOrderModel(sqlDataReader, listCommandOrderModel);
                    }
                    logger.Trace("GetCommandOrdersByIdAsync");
                    return listCommandOrderModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro procurar id da comanda e pedidos, utilizando a procedure USP_Donne_Command_OrdersById assíncrono " + ex.Message;
                    logger.TraceException("GetCommandOrdersByIdAsync");
                    throw new ArgumentNullException(mensagemErro);
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
