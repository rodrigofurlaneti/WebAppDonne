using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class ClientRepository
    {
        #region Properties

        private readonly IConfigurationRoot configurationRoot;
        
        #endregion

        #region Constructor
        public ClientRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<ClientModel> GetAllClients()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<ClientModel> listClientModel = new List<ClientModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ClientGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ClientModel clientObj = new ClientModel();
                    clientObj.ClientId = Convert.ToInt32(rdr["ClientId"]);
                    clientObj.ClientName = Convert.ToString(rdr["ClientName"]);
                    clientObj.ClientPhone = Convert.ToString(rdr["ClientPhone"]);
                    clientObj.ClientAddress = Convert.ToString(rdr["ClientAddress"]);
                    listClientModel.Add(clientObj);
                }
            }
            return listClientModel;
        }

        public ClientModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            ClientModel clientModel = new ClientModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ClientGetById", con);
                cmd.Parameters.AddWithValue("@ClientId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    clientModel.ClientId = Convert.ToInt32(rdr["ClientId"]);
                    clientModel.ClientName = Convert.ToString(rdr["ClientName"]);
                    clientModel.ClientPhone = Convert.ToString(rdr["ClientPhone"]);
                    clientModel.ClientAddress = Convert.ToString(rdr["ClientAddress"]);
                }
            }
            return clientModel;
        }

        public void Insert(ClientModel clientModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ClientInsert", con);
            cmd.Parameters.AddWithValue("@ClientName", clientModel.ClientName);
            cmd.Parameters.AddWithValue("@ClientPhone", clientModel.ClientPhone);
            cmd.Parameters.AddWithValue("@ClientAddress", clientModel.ClientAddress);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int clientId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ClientDelete", con);
            cmd.Parameters.AddWithValue("@ClientId", clientId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(ClientModel clientModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ClientUpdate", con);
            cmd.Parameters.AddWithValue("@ClientId", clientModel.ClientId);
            cmd.Parameters.AddWithValue("@ClientName", clientModel.ClientName);
            cmd.Parameters.AddWithValue("@ClientPhone", clientModel.ClientPhone);
            cmd.Parameters.AddWithValue("@ClientAddress", clientModel.ClientAddress);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
