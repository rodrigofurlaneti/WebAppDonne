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
            try
            {
                this.logger.Trace("Authentication_GetAll");
                commandText = "USP_Donne_Authentication_GetAll";
                List<AuthenticationModel> listAuthenticationModel = new List<AuthenticationModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
            catch (Exception ex)
            {
                this.logger.TraceException("Authentication_GetAll");
                string mensagem = "Erro ao consumir a controler Authentication, rota GetAllAuthentication " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task<IEnumerable<AuthenticationModel>> GetAllAuthenticationsAsync()
        {
                try
                {
                    this.logger.Trace("Authentication_GetAllAsync");
                    commandText = "USP_Donne_Authentication_GetAll";
                    List<AuthenticationModel> listAuthenticationModel = new List<AuthenticationModel>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListAuthenticationModel(sqlDataReader, listAuthenticationModel);
                        }
                    }

                    return listAuthenticationModel;
                }
                catch (Exception ex)
                {
                    this.logger.TraceException("Authentication_GetAllAsync");
                    string mensagem = "Erro ao consumir a controler Authentication, rota GetAuthenticationAsync " + ex.Message;
                    throw new ArgumentNullException(mensagem);
                }
        }

        public AuthenticationModel GetById(int id)
        {
            try
            {
                this.logger.Trace("Authentication_GetById");
                commandText = "USP_Donne_Authentication_GetById";
                AuthenticationModel AuthenticationModel = new AuthenticationModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetAuthenticationModel(sqlDataReader, AuthenticationModel);
                    }
                }

                return AuthenticationModel;
            }
            catch (Exception ex)
            {
                this.logger.TraceException("Authentication_GetById");
                string mensagem = "Erro ao consumir a controler Authentication, rota GetById " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task<AuthenticationModel> GetByIdAsync(int id)
        {
                try
                {
                    this.logger.Trace("Authentication_GetByIdAsync");
                    commandText = "USP_Donne_Authentication_GetById";
                    AuthenticationModel AuthenticationModel = new AuthenticationModel();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetAuthenticationModel(sqlDataReader, AuthenticationModel);
                        }
                    }

                    return AuthenticationModel;
                }
                catch (Exception ex)
                {
                    this.logger.TraceException("Authentication_GetByIdAsync");
                    string mensagem = "Erro ao consumir a controler Authentication, rota GetByIdAsync " + ex.Message;
                    throw new ArgumentNullException(mensagem);
                }
        }

        public void Insert(AuthenticationModel AuthenticationModel)
        {
            try
            {
                this.logger.Trace("Authentication_Insert");
                commandText = "USP_Donne_Authentication_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandAuthenticationModelInsert(sqlCommand, AuthenticationModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                this.logger.TraceException("Authentication_Insert");
                string mensagem = "Erro ao consumir a controler Authentication, rota Insert " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task InsertAsync(AuthenticationModel AuthenticationModel)
        {
            try
            {
                this.logger.Trace("Authentication_InsertAsync");
                commandText = "USP_Donne_Authentication_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandAuthenticationModelInsert(sqlCommand, AuthenticationModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                this.logger.TraceException("Authentication_InsertAsync");
                string mensagem = "Erro ao consumir a controler Authentication, rota InsertAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private static void GetListAuthenticationModel(SqlDataReader sqlDataReader, List<AuthenticationModel> listAuthenticationModel)
        {
            AuthenticationModel authenticationModel = new AuthenticationModel();
            GetAuthenticationModel(sqlDataReader, authenticationModel);
            listAuthenticationModel.Add(authenticationModel);
        }

        private static void GetAuthenticationModel(SqlDataReader sqlDataReader, AuthenticationModel authenticationModel)
        {
            authenticationModel.Id = Convert.ToInt32(sqlDataReader["Id"]);
            authenticationModel.HostedServerName = Convert.ToString(sqlDataReader["HostedServerName"]);
            authenticationModel.ServerInternetProtocol = Convert.ToString(sqlDataReader["ServerInternetProtocol"]);
            authenticationModel.AuthenticationDateTime = Convert.ToString(sqlDataReader["AuthenticationDateTime"]);
            authenticationModel.NavigatorUserAgent = Convert.ToString(sqlDataReader["NavigatorUserAgent"]);
            authenticationModel.ClientInternetProtocol = Convert.ToString(sqlDataReader["ClientInternetProtocol"]);
            authenticationModel.Authenticated = Convert.ToString(sqlDataReader["Authenticated"]);
            authenticationModel.Status = Convert.ToString(sqlDataReader["Status"]);
        }

        private static void GetSqlCommandAuthenticationModelInsert(SqlCommand sqlCommand, AuthenticationModel authenticationModel)
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