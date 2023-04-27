using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class CommandsOrderRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CommandsOrderRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CommandsOrderModel> GetAllCommandsOrders()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandsOrderModel> listCommandsOrderModel = new List<CommandsOrderModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandsOrderGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandsOrderModel commandsOrder = new CommandsOrderModel();
                    commandsOrder.CommandsOrderId = Convert.ToInt32(rdr["CommandsOrderId"]);
                    commandsOrder.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    commandsOrder.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    commandsOrder.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    commandsOrder.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    commandsOrder.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    commandsOrder.StoreName = Convert.ToString(rdr["StoreName"]);
                    commandsOrder.UserId = Convert.ToInt32(rdr["UserId"]);
                    commandsOrder.UserName = Convert.ToString(rdr["UserName"]);
                    listCommandsOrderModel.Add(commandsOrder);
                }
            }
            return listCommandsOrderModel;
        }

        public CommandsOrderModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            CommandsOrderModel commandsOrder = new CommandsOrderModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandsOrderGetById", con);
                cmd.Parameters.AddWithValue("@CommandsOrderId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    commandsOrder.CommandsOrderId = Convert.ToInt32(rdr["CommandsOrderId"]);
                    commandsOrder.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    commandsOrder.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    commandsOrder.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    commandsOrder.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    commandsOrder.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    commandsOrder.StoreName = Convert.ToString(rdr["StoreName"]);
                    commandsOrder.UserId = Convert.ToInt32(rdr["UserId"]);
                    commandsOrder.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            return commandsOrder;
        }

        public void Insert(CommandsOrderModel commandsOrder)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsOrderInsert", con);
            cmd.Parameters.AddWithValue("@OrderId", commandsOrder.OrderId);
            cmd.Parameters.AddWithValue("@CommandsId", commandsOrder.CommandsId);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", commandsOrder.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", commandsOrder.StoreName);
            cmd.Parameters.AddWithValue("@UserId", commandsOrder.UserId);
            cmd.Parameters.AddWithValue("@UserName", commandsOrder.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int commandsOrderId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsOrderDelete", con);
            cmd.Parameters.AddWithValue("@CommandsOrderId", commandsOrderId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(CommandsOrderModel commandsOrder)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsOrderUpdate", con);
            cmd.Parameters.AddWithValue("@CommandsOrderId", commandsOrder.CommandsOrderId);
            cmd.Parameters.AddWithValue("@OrderId", commandsOrder.OrderId);
            cmd.Parameters.AddWithValue("@CommandsId", commandsOrder.CommandsId);
            cmd.Parameters.AddWithValue("@DateInsert", commandsOrder.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", commandsOrder.DateUpdate);
            cmd.Parameters.AddWithValue("@StoreId", commandsOrder.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", commandsOrder.StoreName);
            cmd.Parameters.AddWithValue("@UserId", commandsOrder.UserId);
            cmd.Parameters.AddWithValue("@UserName", commandsOrder.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}