using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class PaymentRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public PaymentRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<PaymentModel> GetAllPayments()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<PaymentModel> listPaymentModel = new List<PaymentModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_PaymentGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PaymentModel paymentModel = new PaymentModel();
                    paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                    paymentModel.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    paymentModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    paymentModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    paymentModel.TotalValue = Convert.ToString(rdr["TotalValue"]);
                    paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    paymentModel.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    paymentModel.StoreName = Convert.ToString(rdr["StoreName"]);
                    paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                    listPaymentModel.Add(paymentModel);
                }
            }
            return listPaymentModel;
        }

        public PaymentModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            PaymentModel paymentModel = new PaymentModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_PaymentGetById", con);
                cmd.Parameters.AddWithValue("@PaymentId", id);

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                    paymentModel.CommandsId = Convert.ToInt32(rdr["CommandsId"]);
                    paymentModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    paymentModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    paymentModel.TotalValue = Convert.ToString(rdr["TotalValue"]);
                    paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    paymentModel.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    paymentModel.StoreName = Convert.ToString(rdr["StoreName"]);
                    paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            return paymentModel;
        }

        public void Insert(PaymentModel paymentModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentInsert", con);
            cmd.Parameters.AddWithValue("@CommandsId", paymentModel.CommandsId);
            cmd.Parameters.AddWithValue("@BuyerId", paymentModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", paymentModel.BuyerName);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            cmd.Parameters.AddWithValue("TotalValue", paymentModel.TotalValue);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", paymentModel.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", paymentModel.StoreName);
            cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int PaymentId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentDelete", con);
            cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(PaymentModel paymentModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentUpdate", con);
            cmd.Parameters.AddWithValue("@CommandsId", paymentModel.CommandsId);
            cmd.Parameters.AddWithValue("@BuyerId", paymentModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", paymentModel.BuyerName);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            cmd.Parameters.AddWithValue("TotalValue", paymentModel.TotalValue);
            cmd.Parameters.AddWithValue("@DateInsert", paymentModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@StoreId", paymentModel.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", paymentModel.StoreName);
            cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
