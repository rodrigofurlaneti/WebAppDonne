using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class CommandBuyerRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CommandBuyerRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CommandBuyerModel> GetCommandBuyer(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandBuyerModel> listCommandsModel = new List<CommandBuyerModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandGetByStatus", con);
                cmd.Parameters.AddWithValue("@Status", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandBuyerModel commandBuyerModel = new CommandBuyerModel();
                    commandBuyerModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    commandBuyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    listCommandsModel.Add(commandBuyerModel);
                }
            }
            return listCommandsModel;
        }
        #endregion
    }
}
