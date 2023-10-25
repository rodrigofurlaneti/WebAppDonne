using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class CommandOrderRepository : BaseRepository
    {
        #region Constructor

        public CommandOrderRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public async Task<IEnumerable<CommandOrderModel>> GetCommandOrdersByIdAsync(int id)
        {
            List<CommandOrderModel> listCommandsModel = new List<CommandOrderModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CommandOrdersById", con);
                    cmd.Parameters.AddWithValue("@CommandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        CommandOrderModel commandOrderModel = new CommandOrderModel();
                        commandOrderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                        commandOrderModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                        commandOrderModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                        commandOrderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        commandOrderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                        commandOrderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                        commandOrderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                        commandOrderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                        listCommandsModel.Add(commandOrderModel);
                    }
                    logger.Trace("GetCommandOrdersByIdAsync");
                    return listCommandsModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro procurar id da comanda e pedidos, utilizando a procedure USP_CommandOrdersById assíncrono " + ex.Message;
                    this.logger.TraceException("GetCommandOrdersByIdAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }
        #endregion
    }
}
