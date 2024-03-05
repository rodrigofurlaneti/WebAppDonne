using System.Data.SqlClient;
using System.Data;
using Domain.Donne;
using System.Collections.Generic;

namespace WebApi.Donne.Infrastructure.FormOfPayment
{
    public class FormOfPaymentRepository : BaseRepository, IFormOfPaymentRepository
    {
        #region Constructor

        public FormOfPaymentRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<FormOfPaymentModel> GetAll()
        {
            commandText = "USP_Donne_FormOfPayment_GetAll";
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListFormOfPaymentModel(sqlDataReader, listFormOfPaymentModel);
                    }
                    logger.Trace("FormOfPayment_GetAll");
                    return listFormOfPaymentModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_Donne_FormOfPayment_GetAll síncrono " + ex.Message;
                    logger.TraceException("FormOfPayment_GetAll");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<FormOfPaymentModel>> GetAllAsync()
        {
            commandText = "USP_Donne_FormOfPayment_GetAll";
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListFormOfPaymentModel(sqlDataReader, listFormOfPaymentModel);
                    }
                    logger.Trace("FormOfPayment_GetAllAsync");
                    return listFormOfPaymentModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_Donne_FormOfPayment_GetAll assíncrono " + ex.Message;
                    logger.TraceException("FormOfPayment_GetAllAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public FormOfPaymentModel GetById(int id)
        {
            try
            {
                commandText = "USP_Donne_FormOfPayment_GetById";
                FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetFormOfPaymentModel(sqlDataReader, formOfPaymentModel);
                    }
                }
                logger.Trace("FormOfPayment_GetById");
                return formOfPaymentModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_GetById síncrono " + ex.Message;
                logger.TraceException("FormOfPayment_GetById");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<FormOfPaymentModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_FormOfPayment_GetById";
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetFormOfPaymentModel(sqlDataReader, formOfPaymentModel);
                    }
                    logger.Trace("FormOfPayment_GetByIdAsync");
                    return formOfPaymentModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_GetById síncrono " + ex.Message;
                    logger.TraceException("FormOfPayment_GetByIdAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(FormOfPaymentModel formOfPaymentModel)
        {
            commandText = "USP_Donne_FormOfPayment_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelInsert(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("FormOfPayment_Insert");
        }

        public async Task InsertAsync(FormOfPaymentModel formOfPaymentModel)
        {
            try
            {
                commandText = "USP_Donne_FormOfPayment_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandBuyerModelInsert(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("FormOfPayment_InsertAsync");
            }
            catch (Exception ex)
            {
                logger.TraceException("FormOfPayment_InsertAsync");
                string mensagemErro = "Erro ao inserir uma nova forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Insert assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int formOfPaymentId)
        {
            commandText = "USP_Donne_FormOfPayment_Delete";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(commandText, con);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("FormOfPayment_Delete");
        }

        public async Task DeleteAsync(int formOfPaymentId)
        {
            try
            {
                commandText = "USP_Donne_FormOfPayment_Delete";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("FormOfPayment_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir uma forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Delete assíncrono " + ex.Message;
                logger.TraceException("FormOfPayment_DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(FormOfPaymentModel formOfPaymentModel)
        {
            commandText = "USP_Donne_FormOfPayment_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelUpdate(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("FormOfPayment_Update");
        }

        public async Task UpdateAsync(FormOfPaymentModel formOfPaymentModel)
        {
            try
            {
                commandText = "USP_Donne_FormOfPayment_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandBuyerModelUpdate(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("FormOfPayment_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Update assíncrono " + ex.Message;
                logger.TraceException("FormOfPayment_UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers
        private static void GetListFormOfPaymentModel(SqlDataReader sqlDataReader, List<FormOfPaymentModel> listFormOfPaymentModel)
        {
            FormOfPaymentModel FormOfPaymentModel = new FormOfPaymentModel();
            GetFormOfPaymentModel(sqlDataReader, FormOfPaymentModel);
            listFormOfPaymentModel.Add(FormOfPaymentModel);
        }

        private static void GetFormOfPaymentModel(SqlDataReader sqlDataReader, FormOfPaymentModel formOfPaymentModel)
        {
            formOfPaymentModel.FormOfPaymentId = Convert.ToInt32(sqlDataReader["FormOfPaymentId"]);
            formOfPaymentModel.FormOfPaymentName = Convert.ToString(sqlDataReader["FormOfPaymentName"]);
            formOfPaymentModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            formOfPaymentModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            formOfPaymentModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            formOfPaymentModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
        }

        private static void GetSqlCommandBuyerModelInsert(SqlCommand sqlCommand, FormOfPaymentModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", formOfPaymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", formOfPaymentModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        private static void GetSqlCommandBuyerModelUpdate(SqlCommand sqlCommand, FormOfPaymentModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentModel.FormOfPaymentId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", formOfPaymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", formOfPaymentModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        #endregion
    }
}
