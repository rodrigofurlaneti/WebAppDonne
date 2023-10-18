using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class BuyerRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        private readonly string connectionString;
        #endregion

        #region Constructor
        public BuyerRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
            connectionString = configurationRoot.GetConnectionString("locaWebDonne");
        }
        #endregion

        #region Methods 

        public IEnumerable<BuyerModel> GetAllBuyers()
        {
            try
            {
                List<BuyerModel> listBuyerModel = new List<BuyerModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
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
                        buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                        listBuyerModel.Add(buyerModel);
                    }
                }
                return listBuyerModel;
            }
            catch (InvalidOperationException ex)
            {
                string mensagem = "A propriedade Connection String não foi inicializada.";
                InvalidOperationException invalidOperationException = new InvalidOperationException(mensagem, ex);
                throw invalidOperationException;
            }
        }

        public IEnumerable<BuyerModel> GetByStatus(int status)
        {
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_BuyerGetStatus", con);
                cmd.Parameters.AddWithValue("@Status", status);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BuyerModel buyerModel = new BuyerModel();
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                    buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                    listBuyerModel.Add(buyerModel);
                }
            }
            return listBuyerModel;
        }
        public BuyerModel GetById(int id)
        {
            BuyerModel buyerModel = new BuyerModel();
            using (SqlConnection con = new SqlConnection(connectionString))
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
                    buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            return buyerModel;
        }

        public void Insert(BuyerModel buyerModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_BuyerInsert", con);
                cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
                cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
                cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception(ex.Message);
                throw exception;
            }

        }

        public void Delete(int buyerId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_BuyerDelete", con);
                cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Exception exception = new Exception(ex.Message);
                throw exception;
            }
        }

        public void Update(BuyerModel buyerModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
            cmd.Parameters.AddWithValue("@BuyerId", buyerModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
            cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
            cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
            cmd.Parameters.AddWithValue("@DateInsert", buyerModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
