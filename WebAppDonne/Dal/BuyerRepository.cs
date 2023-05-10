using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class BuyerRepository
    {
        #region Properties

        private readonly IConfigurationRoot configurationRoot;
        
        #endregion

        #region Constructor
        public BuyerRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<BuyerModel> GetAllBuyers()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_BuyerGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BuyerModel buyerModel = new BuyerModel();
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                    listBuyerModel.Add(buyerModel);
                }
            }
            return listBuyerModel;
        }

        public BuyerModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            BuyerModel buyerModel = new BuyerModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_BuyerGetById", con);
                cmd.Parameters.AddWithValue("@BuyerId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                }
            }
            return buyerModel;
        }

        public void Insert(BuyerModel buyerModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerInsert", con);
            cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
            cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
            cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int buyerId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerDelete", con);
            cmd.Parameters.AddWithValue("@BuyerId", buyerId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(BuyerModel buyerModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
            cmd.Parameters.AddWithValue("@BuyerId", buyerModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
            cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
            cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
