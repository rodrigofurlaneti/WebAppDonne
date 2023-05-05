using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class CommandsRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CommandsRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CommandsModel> GetAllCommands()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandsModel> listCommandsModel = new List<CommandsModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandsGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandsModel commands = new CommandsModel();
                    commands.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    commands.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    commands.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    commands.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    commands.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    commands.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    commands.StoreName = Convert.ToString(rdr["StoreName"]);
                    commands.UserId = Convert.ToInt32(rdr["UserId"]);
                    commands.UserName = Convert.ToString(rdr["UserName"]);
                    commands.Status = Convert.ToBoolean(rdr["Status"]);
                    listCommandsModel.Add(commands);
                }
            }
            return listCommandsModel;
        }

        public CommandsModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            CommandsModel commands = new CommandsModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandsGetById", con);
                cmd.Parameters.AddWithValue("@CommandsId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    commands.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    commands.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    commands.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    commands.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    commands.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    commands.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    commands.StoreName = Convert.ToString(rdr["StoreName"]);
                    commands.UserId = Convert.ToInt32(rdr["UserId"]);
                    commands.UserName = Convert.ToString(rdr["UserName"]);
                    commands.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            return commands;
        }

        public void Insert(CommandsModel commands)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsInsert", con);
            cmd.Parameters.AddWithValue("@BuyerId", commands.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commands.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", commands.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", commands.StoreName);
            cmd.Parameters.AddWithValue("@UserId", commands.UserId);
            cmd.Parameters.AddWithValue("@UserName", commands.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int InsertReturnId(CommandsModel commands)
        {
            int newId = 0;
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsInsertReturnId", con);
            cmd.Parameters.AddWithValue("@Identity", commands.CommandsId);//OUTPUT
            cmd.Parameters.AddWithValue("@BuyerId", commands.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commands.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", commands.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", commands.StoreName);
            cmd.Parameters.AddWithValue("@UserId", commands.UserId);
            cmd.Parameters.AddWithValue("@UserName", commands.UserName);
            cmd.Parameters.AddWithValue("@Status", commands.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                newId = Convert.ToInt32(result);
            }
            con.Close();
            return newId;
        }

        public void Delete(int CommandsId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsDelete", con);
            cmd.Parameters.AddWithValue("@CommandsId", CommandsId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(CommandsModel commands)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandsUpdate", con);
            cmd.Parameters.AddWithValue("@CommandsId", commands.CommandsId);
            cmd.Parameters.AddWithValue("@BuyerId", commands.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commands.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", commands.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", commands.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", commands.StoreName);
            cmd.Parameters.AddWithValue("@UserId", commands.UserId);
            cmd.Parameters.AddWithValue("@UserName", commands.UserName);
            cmd.Parameters.AddWithValue("@Status", commands.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
