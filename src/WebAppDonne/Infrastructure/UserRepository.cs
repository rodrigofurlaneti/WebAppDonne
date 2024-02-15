using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class UserRepository : BaseRepository
    {
        #region Constructor

        public UserRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<UserModel> GetAllUsers()
        {
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                logger.Trace("GetAllUsers");
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_GetAll", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListUserModel(sqlDataReader, listUserModel);
                }
            }
            return listUserModel;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_GetAll", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    listUserModel = GetListUserModel(sqlDataReader, listUserModel);
                }
                this.logger.Trace("User_GetAllUserAsync");
                return listUserModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetUserAsync " + ex.Message;
                this.logger.TraceException("User_GetAllUserAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public UserModel GetById(int id)
        {
            UserModel userModel = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_UserGetById", con);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    userModel = GetUserModel(sqlDataReader, userModel);
                }
            }
            logger.Trace("GetById");
            return userModel;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_GetById", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    userModel = GetUserModel(sqlDataReader, userModel);
                }
                this.logger.Trace("User_GetByIdAsync");
                return userModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByIdAsync " + ex.Message;
                this.logger.TraceException("User_GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public UserModel GetByName(string userName)
        {
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_GetByName", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserName", userName);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    userModel = GetUserModel(sqlDataReader, userModel);
                }
            }
            logger.Trace("User_GetByName");
            return userModel;
        }


        public async Task<UserModel> GetByNameAsync(string userName)
        {
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_GetByName", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserName", userName);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    userModel = GetUserModel(sqlDataReader, userModel);
                }
                logger.Trace("User_GetByNameAsync");
                return userModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByNameAsync " + ex.Message;
                this.logger.TraceException("User_GetByNameAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Insert(UserModel userModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_Insert", sqlConnection);
            GetSqlCommandUserModelInsert(sqlCommand, userModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("User_Insert");
        }

        public async Task InsertAsync(UserModel userModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_Insert", sqlConnection);
                GetSqlCommandUserModelInsert(sqlCommand, userModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("User_InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota InsertAsync " + ex.Message;
                this.logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Delete(int UserId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_Donne_User_Delete", con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("User_Delete");
        }

        public async Task DeleteAsync(int UserId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_Donne_User_Delete", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("User_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota DeleteAsync " + ex.Message;
                this.logger.TraceException("User_DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Update(UserModel userModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_Update", sqlConnection);
            GetSqlCommandUserModelUpdate(sqlCommand, userModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("User_Update");
        }

        public async Task UpdateAsync(UserModel userModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_User_Update", sqlConnection);
                GetSqlCommandUserModelUpdate(sqlCommand, userModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("User_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota UpdateAsync " + ex.Message;
                this.logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private List<UserModel> GetListUserModel(SqlDataReader sqlDataReader, List<UserModel> listUserModel)
        {
            UserModel UserModel = new UserModel();
            UserModel = GetUserModel(sqlDataReader, UserModel);
            listUserModel.Add(UserModel);
            return listUserModel;
        }

        private UserModel GetUserModel(SqlDataReader sqlDataReader, UserModel userModel)
        {
            userModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            userModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            userModel.UserPassword = Convert.ToString(sqlDataReader["UserPassword"]);
            userModel.ProfileId = Convert.ToInt32(sqlDataReader["ProfileId"]);
            userModel.ProfileName = Convert.ToString(sqlDataReader["ProfileName"]);
            userModel.Status = Convert.ToInt32(sqlDataReader["Status"]);
            return userModel;
        }

        private void GetSqlCommandUserModelUpdate(SqlCommand sqlCommand, UserModel userModel)
        {
            sqlCommand.Parameters.AddWithValue("@UserId", userModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
            sqlCommand.Parameters.AddWithValue("@UserPassword", userModel.UserPassword);
            sqlCommand.Parameters.AddWithValue("@ProfileId", Convert.ToInt32(userModel.ProfileId));
            sqlCommand.Parameters.AddWithValue("@ProfileName", userModel.ProfileName);
            sqlCommand.Parameters.AddWithValue("@Status", Convert.ToInt32(userModel.Status));
        }

        private void GetSqlCommandUserModelInsert(SqlCommand sqlCommand, UserModel userModel)
        {
            sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
            sqlCommand.Parameters.AddWithValue("@UserPassword", userModel.UserPassword);
            sqlCommand.Parameters.AddWithValue("@ProfileId", Convert.ToInt32(userModel.ProfileId));
            sqlCommand.Parameters.AddWithValue("@ProfileName", userModel.ProfileName);
            sqlCommand.Parameters.AddWithValue("@Status", Convert.ToInt32(userModel.Status));
        }

        #endregion
    }
}