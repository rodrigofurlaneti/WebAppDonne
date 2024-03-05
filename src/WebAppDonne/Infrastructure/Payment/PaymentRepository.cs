using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Payment
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        #region Constructor

        public PaymentRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<PaymentModel> GetAll()
        {
            commandText = "USP_Donne_Payment_GetAll";
            List<PaymentModel> listPaymentModel = new List<PaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListPaymentModel(sqlDataReader, listPaymentModel);
                }
            }
            logger.Trace("Payment_GetAll");
            return listPaymentModel;
        }

        public async Task<IEnumerable<PaymentModel>> GetAllAsync()
        {
            commandText = "USP_Donne_Payment_GetAll";
            List<PaymentModel> listPaymentModel = new List<PaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListPaymentModel(sqlDataReader, listPaymentModel);
                    }
                    logger.Trace("Payment_GetAllAsync");
                    return listPaymentModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a método GetAllPaymentsAsync " + ex.Message;
                    logger.TraceException("Payment_GetAllAsync");
                    throw new ArgumentNullException(mensagem);
                }
        }

        public PaymentModel GetById(int id)
        {
            commandText = "USP_Donne_Payment_GetById";
            PaymentModel paymentModel = new PaymentModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetPaymentModel(sqlDataReader, paymentModel);
                }
            }
            logger.Trace("GetById");
            return paymentModel;
        }

        public async Task<PaymentModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_Payment_GetById";
            PaymentModel paymentModel = new PaymentModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@PaymentId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetPaymentModel(sqlDataReader, paymentModel);
                    }
                    logger.Trace("Payment_GetByIdAsync");
                    return paymentModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a método GetByIdAsync " + ex.Message;
                    logger.TraceException("Payment_GetByIdAsync");
                    throw new ArgumentNullException(mensagem);
                }
        }

        public void Insert(PaymentModel paymentModel)
        {
            commandText = "USP_Donne_Payment_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandPaymentModelInsert(sqlCommand, paymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Payment_Insert");
        }

        public async Task InsertAsync(PaymentModel paymentModel)
        {
            try
            {
                commandText = "USP_Donne_Payment_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandPaymentModelInsert(sqlCommand, paymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Payment_InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método InsertAsync " + ex.Message;
                logger.TraceException("Payment_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }
        public void Delete(int paymentId)
        {
            commandText = "USP_Donne_Payment_Delete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PaymentId", paymentId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Payment_Delete");
        }

        public async Task DeleteAsync(int paymentId)
        {
            try
            {
                commandText = "USP_Donne_Payment_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@PaymentId", paymentId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Payment_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método InsertAsync " + ex.Message;
                logger.TraceException("Payment_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Update(PaymentModel paymentModel)
        {
            commandText = "USP_Donne_Payment_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandPaymentModelUpdate(sqlCommand, paymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Payment_Update");
        }

        public async Task UpdateAsync(PaymentModel paymentModel)
        {
            try
            {
                commandText = "USP_Donne_Payment_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandPaymentModelUpdate(sqlCommand, paymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Payment_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método UpdateAsync " + ex.Message;
                logger.TraceException("Payment_UpdatetAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private static void GetListPaymentModel(SqlDataReader sqlDataReader, List<PaymentModel> listPaymentModel)
        {
            PaymentModel paymentModel = new PaymentModel();
            GetPaymentModel(sqlDataReader, paymentModel);
            listPaymentModel.Add(paymentModel);
        }

        private static void GetPaymentModel(SqlDataReader sqlDataReader, PaymentModel paymentModel)
        {
            paymentModel.PaymentId = Convert.ToInt32(sqlDataReader["PaymentId"]);
            paymentModel.CommandId = Convert.ToInt32(sqlDataReader["CommandId"]);
            paymentModel.FormOfPaymentId = Convert.ToInt32(sqlDataReader["FormOfPaymentId"]);
            paymentModel.FormOfPaymentName = Convert.ToString(sqlDataReader["FormOfPaymentName"]);
            paymentModel.PaymentAmount = Convert.ToString(sqlDataReader["PaymentAmount"]);
            paymentModel.PaymentType = Convert.ToString(sqlDataReader["PaymentType"]);
            paymentModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            paymentModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            paymentModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            paymentModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
        }

        private static void GetSqlCommandPaymentModelInsert(SqlCommand sqlCommand, PaymentModel paymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@PaymentAmount", paymentModel.PaymentAmount);
            sqlCommand.Parameters.AddWithValue("@PaymentType", paymentModel.PaymentType);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", paymentModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", paymentModel.UserName);
        }

        private static void GetSqlCommandPaymentModelUpdate(SqlCommand sqlCommand, PaymentModel paymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@PaymentId", paymentModel.PaymentId);
            sqlCommand.Parameters.AddWithValue("@CommandId", paymentModel.CommandId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", paymentModel.FormOfPaymentId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", paymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@PaymentAmount", paymentModel.PaymentAmount);
            sqlCommand.Parameters.AddWithValue("@PaymentType", paymentModel.PaymentType);
            sqlCommand.Parameters.AddWithValue("@DateInsert", paymentModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", paymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", paymentModel.UserName);
        }
        #endregion
    }
}
