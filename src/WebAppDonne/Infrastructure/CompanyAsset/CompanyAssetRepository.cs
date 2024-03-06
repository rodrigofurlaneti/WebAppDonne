using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure.CompanyAsset
{
    public class CompanyAssetRepository : BaseRepository, ICompanyAssetRepository
    {
        #region Constructor

        public CompanyAssetRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<CompanyAssetModel> GetAll()
        {
            commandText = "USP_Donne_CompanyAsset_GetAll";
            List<CompanyAssetModel> listCompanyAssetModel = new List<CompanyAssetModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListCompanyAssetModel(sqlDataReader, listCompanyAssetModel);
                    }
                    logger.Trace("CompanyAsset_GetAll");
                    return listCompanyAssetModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_Donne_CompanyAsset_GetAll síncrono " + ex.Message;
                    logger.TraceException("CompanyAsset_GetAll");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<CompanyAssetModel>> GetAllAsync()
        {
            commandText = "USP_Donne_CompanyAsset_GetAll";
            List<CompanyAssetModel> listCompanyAssetModel = new List<CompanyAssetModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListCompanyAssetModel(sqlDataReader, listCompanyAssetModel);
                    }
                    logger.Trace("CompanyAsset_GetAllAsync");
                    return listCompanyAssetModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_Donne_CompanyAsset_GetAll assíncrono " + ex.Message;
                    logger.TraceException("CompanyAsset_GetAllAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public CompanyAssetModel GetById(int id)
        {
            try
            {
                commandText = "USP_Donne_CompanyAsset_GetById";
                CompanyAssetModel formOfPaymentModel = new CompanyAssetModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CompanyAssetId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetCompanyAssetModel(sqlDataReader, formOfPaymentModel);
                    }
                }
                logger.Trace("CompanyAsset_GetById");
                return formOfPaymentModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_CompanyAsset_GetById síncrono " + ex.Message;
                logger.TraceException("CompanyAsset_GetById");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<CompanyAssetModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_CompanyAsset_GetById";
            CompanyAssetModel formOfPaymentModel = new CompanyAssetModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CompanyAssetId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetCompanyAssetModel(sqlDataReader, formOfPaymentModel);
                    }
                    logger.Trace("CompanyAsset_GetByIdAsync");
                    return formOfPaymentModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_CompanyAsset_GetById síncrono " + ex.Message;
                    logger.TraceException("CompanyAsset_GetByIdAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(CompanyAssetModel formOfPaymentModel)
        {
            commandText = "USP_Donne_CompanyAsset_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandCompanyAssetModelInsert(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("CompanyAsset_Insert");
        }

        public async Task InsertAsync(CompanyAssetModel formOfPaymentModel)
        {
            try
            {
                commandText = "USP_Donne_CompanyAsset_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandCompanyAssetModelInsert(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("CompanyAsset_InsertAsync");
            }
            catch (Exception ex)
            {
                logger.TraceException("CompanyAsset_InsertAsync");
                string mensagemErro = "Erro ao inserir uma nova forma de pagamento, utilizando a procedure USP_Donne_CompanyAsset_Insert assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int formOfPaymentId)
        {
            commandText = "USP_Donne_CompanyAsset_Delete";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(commandText, con);
            cmd.Parameters.AddWithValue("@CompanyAssetId", formOfPaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("CompanyAsset_Delete");
        }

        public async Task DeleteAsync(int formOfPaymentId)
        {
            try
            {
                commandText = "USP_Donne_CompanyAsset_Delete";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@CompanyAssetId", formOfPaymentId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("CompanyAsset_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir uma forma de pagamento, utilizando a procedure USP_Donne_CompanyAsset_Delete assíncrono " + ex.Message;
                logger.TraceException("CompanyAsset_DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(CompanyAssetModel formOfPaymentModel)
        {
            commandText = "USP_Donne_CompanyAsset_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandCompanyAssetModelUpdate(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("CompanyAsset_Update");
        }

        public async Task UpdateAsync(CompanyAssetModel formOfPaymentModel)
        {
            try
            {
                commandText = "USP_Donne_CompanyAsset_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandCompanyAssetModelUpdate(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("CompanyAsset_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma forma de pagamento, utilizando a procedure USP_Donne_CompanyAsset_Update assíncrono " + ex.Message;
                logger.TraceException("CompanyAsset_UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion

        #region Helpers
        private static void GetListCompanyAssetModel(SqlDataReader sqlDataReader, List<CompanyAssetModel> listCompanyAssetModel)
        {
            CompanyAssetModel CompanyAssetModel = new CompanyAssetModel();
            GetCompanyAssetModel(sqlDataReader, CompanyAssetModel);
            listCompanyAssetModel.Add(CompanyAssetModel);
        }

        private static void GetCompanyAssetModel(SqlDataReader sqlDataReader, CompanyAssetModel formOfPaymentModel)
        {
            formOfPaymentModel.CompanyAssetId = Convert.ToInt32(sqlDataReader["CompanyAssetId"]);
            formOfPaymentModel.CompanyAssetName = Convert.ToString(sqlDataReader["CompanyAssetName"]);
            formOfPaymentModel.CostPrice = Convert.ToString(sqlDataReader["CostPrice"]);
            formOfPaymentModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            formOfPaymentModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            formOfPaymentModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            formOfPaymentModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
        }

        private static void GetSqlCommandCompanyAssetModelInsert(SqlCommand sqlCommand, CompanyAssetModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyAssetName", formOfPaymentModel.CompanyAssetName);
            sqlCommand.Parameters.AddWithValue("@CostPrice", formOfPaymentModel.CostPrice);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", formOfPaymentModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        private static void GetSqlCommandCompanyAssetModelUpdate(SqlCommand sqlCommand, CompanyAssetModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@CompanyAssetId", formOfPaymentModel.CompanyAssetId);
            sqlCommand.Parameters.AddWithValue("@CompanyAssetName", formOfPaymentModel.CompanyAssetName);
            sqlCommand.Parameters.AddWithValue("@CostPrice", formOfPaymentModel.CostPrice);
            sqlCommand.Parameters.AddWithValue("@DateInsert", formOfPaymentModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        #endregion
    }
}
