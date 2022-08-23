using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class StoreRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public StoreRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<StoreModel> GetAllStores()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<StoreModel> listStoreModel = new List<StoreModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_StoreGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StoreModel Store = new StoreModel();
                    Store.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    Store.StoreName = Convert.ToString(rdr["StoreName"]);
                    Store.StoreCnpj = Convert.ToString(rdr["StoreCnpj"]);
                    Store.StoreAddress = Convert.ToString(rdr["StoreAddress"]);
                    Store.Status = Convert.ToBoolean(rdr["Status"]);
                    listStoreModel.Add(Store);
                }
            }
            return listStoreModel;
        }

        public StoreModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            StoreModel Store = new StoreModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_StoreGetById", con);
                cmd.Parameters.AddWithValue("@StoreId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Store.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    Store.StoreName = Convert.ToString(rdr["StoreName"]);
                    Store.StoreCnpj = Convert.ToString(rdr["StoreCnpj"]);
                    Store.StoreAddress = Convert.ToString(rdr["StoreAddress"]);
                    Store.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            return Store;
        }

        public void Insert(StoreModel Store)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_StoreInsert", con);
            cmd.Parameters.AddWithValue("@StoreName", Store.StoreName);
            cmd.Parameters.AddWithValue("@StoreCnpj", Store.StoreCnpj);
            cmd.Parameters.AddWithValue("@StoreAddress", Store.StoreAddress);
            cmd.Parameters.AddWithValue("@Status", Store.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int StoreId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_StoreDelete", con);
            cmd.Parameters.AddWithValue("@StoreId", StoreId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(StoreModel Store)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_StoreUpdate", con);
            cmd.Parameters.AddWithValue("@StoreId", Store.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", Store.StoreName);
            cmd.Parameters.AddWithValue("@StoreCnpj", Store.StoreCnpj);
            cmd.Parameters.AddWithValue("@StoreAddress", Store.StoreAddress);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
