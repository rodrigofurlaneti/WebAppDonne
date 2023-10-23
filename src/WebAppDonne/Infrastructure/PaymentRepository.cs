using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure
{
    public class PaymentRepository : BaseRepository
    {
        #region Constructor

        public PaymentRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<PaymentModel> GetAllPayments()
        {
            List<PaymentModel> listPaymentModel = new List<PaymentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_PaymentGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PaymentModel paymentModel = new PaymentModel();
                    paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                    paymentModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    paymentModel.PaymentAmount = Convert.ToString(rdr["PaymentAmount"]);
                    paymentModel.PaymentType = Convert.ToString(rdr["PaymentType"]);
                    paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                    listPaymentModel.Add(paymentModel);
                }
            }
            logger.Trace("GetAllPayments");
            return listPaymentModel;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsAsync()
        {
            List<PaymentModel> listPaymentModel = new List<PaymentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                SqlCommand cmd = new SqlCommand("USP_PaymentGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                        PaymentModel paymentModel = new PaymentModel();
                        paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                        paymentModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                        paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                        paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                        paymentModel.PaymentAmount = Convert.ToString(rdr["PaymentAmount"]);
                        paymentModel.PaymentType = Convert.ToString(rdr["PaymentType"]);
                        paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                        listPaymentModel.Add(paymentModel);
                }
                logger.Trace("GetAllPaymentsAsync");
                return listPaymentModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método GetAllPaymentsAsync " + ex.Message;
                logger.TraceException("GetAllPaymentsAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public PaymentModel GetById(int id)
        {
            PaymentModel paymentModel = new PaymentModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_PaymentGetById", con);
                cmd.Parameters.AddWithValue("@PaymentId", id);

                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                    paymentModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    paymentModel.PaymentAmount = Convert.ToString(rdr["PaymentAmount"]);
                    paymentModel.PaymentType = Convert.ToString(rdr["PaymentType"]);
                    paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            logger.Trace("GetById");
            return paymentModel;
        }

        public async Task<PaymentModel> GetByIdAsync(int id)
        {
            PaymentModel paymentModel = new PaymentModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                    SqlCommand cmd = new SqlCommand("USP_PaymentGetById", con);
                    cmd.Parameters.AddWithValue("@PaymentId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        paymentModel.PaymentId = Convert.ToInt32(rdr["PaymentId"]);
                        paymentModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                        paymentModel.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                        paymentModel.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                        paymentModel.PaymentAmount = Convert.ToString(rdr["PaymentAmount"]);
                        paymentModel.PaymentType = Convert.ToString(rdr["PaymentType"]);
                        paymentModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        paymentModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        paymentModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        paymentModel.UserName = Convert.ToString(rdr["UserName"]);
                    }
                logger.Trace("GetByIdAsync");
                return paymentModel;
            }
            catch (Exception ex)
            {
                    string mensagem = "Erro ao consumir a método GetByIdAsync " + ex.Message;
                    logger.TraceException("GetByIdAsync");
                    throw new ArgumentNullException(mensagem);
            }
        }

        public void Insert(PaymentModel paymentModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentInsert", con);
            cmd.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            cmd.Parameters.AddWithValue("PaymentAmount", paymentModel.PaymentAmount);
            cmd.Parameters.AddWithValue("PaymentType", paymentModel.PaymentType);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }


        public async Task InsertAsync(PaymentModel paymentModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_PaymentInsert", con);
                cmd.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
                cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
                cmd.Parameters.AddWithValue("PaymentAmount", paymentModel.PaymentAmount);
                cmd.Parameters.AddWithValue("PaymentType", paymentModel.PaymentType);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método InsertAsync " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }
        public void Delete(int PaymentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentDelete", con);
            cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int PaymentId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_PaymentDelete", con);
                cmd.Parameters.AddWithValue("@PaymentId", PaymentId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método InsertAsync " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Update(PaymentModel paymentModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_PaymentUpdate", con);
            cmd.Parameters.AddWithValue("@PaymentId", paymentModel.PaymentId);
            cmd.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            cmd.Parameters.AddWithValue("@PaymentAmount", paymentModel.PaymentAmount);
            cmd.Parameters.AddWithValue("@PaymentType", paymentModel.PaymentType);
            cmd.Parameters.AddWithValue("@DateInsert", paymentModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(PaymentModel paymentModel)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_PaymentUpdate", con);
                cmd.Parameters.AddWithValue("@PaymentId", paymentModel.PaymentId);
                cmd.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
                cmd.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
                cmd.Parameters.AddWithValue("@PaymentAmount", paymentModel.PaymentAmount);
                cmd.Parameters.AddWithValue("@PaymentType", paymentModel.PaymentType);
                cmd.Parameters.AddWithValue("@DateInsert", paymentModel.DateInsert);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", paymentModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", paymentModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método UpdateAsync " + ex.Message;
                logger.TraceException("UpdatetAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion
    }
}
