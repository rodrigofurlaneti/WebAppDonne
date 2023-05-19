using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class CommandOrderRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CommandOrderRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CommandOrderModel> GetCommandOrder(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandOrderModel> listCommandsModel = new List<CommandOrderModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandOrdersById", con);
                cmd.Parameters.AddWithValue("@CommandId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
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
                    listCommandsModel.Add(commandOrderModel);
                }
            }
            return listCommandsModel;
        }
        #endregion
    }
}
