using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class AuthenticationRepository : BaseRepository
    {
        #region Constructor

        public AuthenticationRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<AuthenticationModel> GetAllAuthentications()
        {
            List<AuthenticationModel> listAuthenticationModel = new List<AuthenticationModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                logger.Trace("GetAllAuthentications");
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_GetAll", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListAuthenticationModel(sqlDataReader, listAuthenticationModel);
                }
            }
            return listAuthenticationModel;
        }

        public async Task<IEnumerable<AuthenticationModel>> GetAllAuthenticationsAsync()
        {
            List<AuthenticationModel> listAuthenticationModel = new List<AuthenticationModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    logger.Trace("Authentication_GetAllAsync");
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_GetAll", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListAuthenticationModel(sqlDataReader, listAuthenticationModel);
                    }
                    return listAuthenticationModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler Authentication, rota GetAuthenticationAsync " + ex.Message;
                    logger.TraceException("GetAllAuthenticationAsync");
                    throw new ArgumentNullException(mensagem);
                }

        }

        public AuthenticationModel GetById(int id)
        {
            AuthenticationModel AuthenticationModel = new AuthenticationModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_GetById", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetAuthenticationModel(sqlDataReader, AuthenticationModel);
                }
            }
            logger.Trace("Authentication_GetById");
            return AuthenticationModel;
        }

        public async Task<AuthenticationModel> GetByIdAsync(int id)
        {
            AuthenticationModel AuthenticationModel = new AuthenticationModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    logger.Trace("Authentication_GetById_Async");
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_GetById", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetAuthenticationModel(sqlDataReader, AuthenticationModel);
                    }
                    return AuthenticationModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler Authentication, rota GetByIdAsync " + ex.Message;
                    logger.TraceException("GetByIdAsync");
                    throw new ArgumentNullException(mensagem);
                }
        }

        public void Insert(AuthenticationModel AuthenticationModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Insert", sqlConnection);
            GetSqlCommandAuthenticationModel(sqlCommand, AuthenticationModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Authentication_Insert");
        }

        public async Task InsertAsync(AuthenticationModel AuthenticationModel)
        {
            try
            {
                logger.Trace("InsertAsync");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Insert", sqlConnection);
                GetSqlCommandAuthenticationModel(sqlCommand, AuthenticationModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota InsertAsync " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Delete", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Authentication_Delete");
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                logger.Trace("DeleteAsync");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Delete", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota DeleteAsync " + ex.Message;
                logger.TraceException("Authentication_DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Update(AuthenticationModel AuthenticationModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Update", sqlConnection);
            GetSqlCommandAuthenticationModel(sqlCommand, AuthenticationModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Authentication_Update");
        }

        public async Task UpdateAsync(AuthenticationModel AuthenticationModel)
        {
            try
            {
                logger.Trace("UpdateAsync");
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Authentication_Update", sqlConnection);
                GetSqlCommandAuthenticationModel(sqlCommand, AuthenticationModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler Authentication, rota UpdateAsync " + ex.Message;
                logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private List<AuthenticationModel> GetListAuthenticationModel(SqlDataReader sqlDataReader, List<AuthenticationModel> listAuthenticationModel)
        {
            AuthenticationModel authenticationModel = new AuthenticationModel();
            authenticationModel = GetAuthenticationModel(sqlDataReader, authenticationModel);
            listAuthenticationModel.Add(authenticationModel);
            return listAuthenticationModel;
        }

        private AuthenticationModel GetAuthenticationModel(SqlDataReader sqlDataReader, AuthenticationModel authenticationModel)
        {
            authenticationModel.Id = Convert.ToInt32(sqlDataReader["Id"]);
            authenticationModel.HostedServerName = Convert.ToString(sqlDataReader["HostedServerName"]);
            authenticationModel.ServerInternetProtocol = Convert.ToString(sqlDataReader["ServerInternetProtocol"]);
            authenticationModel.AuthenticationDateTime = Convert.ToString(sqlDataReader["AuthenticationDateTime"]);
            authenticationModel.NavigatorUserAgent = Convert.ToString(sqlDataReader["NavigatorUserAgent"]);
            authenticationModel.ClientInternetProtocol = Convert.ToString(sqlDataReader["ClientInternetProtocol"]);
            authenticationModel.Authenticated = Convert.ToString(sqlDataReader["Authenticated"]);
            authenticationModel.Status = Convert.ToString(sqlDataReader["Status"]);
            return authenticationModel;
        }

        private void GetSqlCommandAuthenticationModel(SqlCommand sqlCommand, AuthenticationModel authenticationModel)
        {
            sqlCommand.Parameters.AddWithValue("@HostedServerName", authenticationModel.HostedServerName);
            sqlCommand.Parameters.AddWithValue("@ServerInternetProtocol", authenticationModel.ServerInternetProtocol);
            sqlCommand.Parameters.AddWithValue("@AuthenticationDateTime", authenticationModel.AuthenticationDateTime);
            sqlCommand.Parameters.AddWithValue("@NavigatorUserAgent", authenticationModel.NavigatorUserAgent);
            sqlCommand.Parameters.AddWithValue("@ClientInternetProtocol", authenticationModel.ClientInternetProtocol);
            sqlCommand.Parameters.AddWithValue("@Authenticated", Convert.ToInt32(authenticationModel.Authenticated));
            sqlCommand.Parameters.AddWithValue("@Status", authenticationModel.Status);
        }

        #endregion
    }
}