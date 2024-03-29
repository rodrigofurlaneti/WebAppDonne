﻿using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure.User
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Constructor

        public UserRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<UserModel> GetAll()
        {
            commandText = "USP_Donne_User_GetAll";
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                logger.Trace("GetAllUsers");
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            commandText = "USP_Donne_User_GetAll";
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListUserModel(sqlDataReader, listUserModel);
                    }
                    logger.Trace("User_GetAllUserAsync");
                    return listUserModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler User, rota GetUserAsync " + ex.Message;
                    logger.TraceException("User_GetAllUserAsync");
                    throw new ArgumentNullException(mensagem);
                }

        }

        public UserModel GetById(int id)
        {
            commandText = "USP_Donne_User_GetById";
            UserModel userModel = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetUserModel(sqlDataReader, userModel);
                }
            }
            logger.Trace("GetById");
            return userModel;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_User_GetById";
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@UserId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetUserModel(sqlDataReader, userModel);
                    }
                    logger.Trace("User_GetByIdAsync");
                    return userModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler User, rota GetByIdAsync " + ex.Message;
                    logger.TraceException("User_GetByIdAsync");
                    throw new ArgumentNullException(mensagem);
                }
        }

        public UserModel GetByName(string userName)
        {
            commandText = "USP_Donne_User_GetByName";
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@UserName", userName);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetUserModel(sqlDataReader, userModel);
                }
            }
            logger.Trace("User_GetByName");
            return userModel;
        }


        public async Task<UserModel> GetByNameAsync(string userName)
        {
            commandText = "USP_Donne_User_GetByName";
            UserModel userModel = new UserModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@UserName", userName);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetUserModel(sqlDataReader, userModel);
                    }
                    logger.Trace("User_GetByNameAsync");
                    return userModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a controler User, rota GetByNameAsync " + ex.Message;
                    logger.TraceException("User_GetByNameAsync");
                    throw new ArgumentNullException(mensagem);
                }
        }

        public void Insert(UserModel userModel)
        {
            commandText = "USP_Donne_User_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
                commandText = "USP_Donne_User_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Delete(int userId)
        {
            try
            {
                this.logger.Trace("User_Delete");
                commandText = "USP_Donne_User_Delete";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                this.logger.TraceException("User_Delete");
                string mensagem = "Erro ao consumir a controler User, rota Delete " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }
        }

        public async Task DeleteAsync(int userId)
        {
            try
            {
                this.logger.Trace("User_DeleteAsync");
                commandText = "USP_Donne_User_Delete";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                this.logger.TraceException("User_DeleteAsync");
                string mensagem = "Erro ao consumir a controler User, rota DeleteAsync " + ex.Message;
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Update(UserModel userModel)
        {
            commandText = "USP_Donne_User_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
                commandText = "USP_Donne_User_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
                logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion

        #region Helpers
        private static void GetListUserModel(SqlDataReader sqlDataReader, List<UserModel> listUserModel)
        {
            UserModel userModel = new UserModel();
            GetUserModel(sqlDataReader, userModel);
            listUserModel.Add(userModel);
        }

        private static void GetUserModel(SqlDataReader sqlDataReader, UserModel userModel)
        {
            userModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            userModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            userModel.UserPassword = Convert.ToString(sqlDataReader["UserPassword"]);
            userModel.ProfileId = Convert.ToInt32(sqlDataReader["ProfileId"]);
            userModel.ProfileName = Convert.ToString(sqlDataReader["ProfileName"]);
            userModel.Status = Convert.ToInt32(sqlDataReader["Status"]);
        }

        private static void GetSqlCommandUserModelUpdate(SqlCommand sqlCommand, UserModel userModel)
        {
            sqlCommand.Parameters.AddWithValue("@UserId", userModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", userModel.UserName);
            sqlCommand.Parameters.AddWithValue("@UserPassword", userModel.UserPassword);
            sqlCommand.Parameters.AddWithValue("@ProfileId", Convert.ToInt32(userModel.ProfileId));
            sqlCommand.Parameters.AddWithValue("@ProfileName", userModel.ProfileName);
            sqlCommand.Parameters.AddWithValue("@Status", Convert.ToInt32(userModel.Status));
        }

        private static void GetSqlCommandUserModelInsert(SqlCommand sqlCommand, UserModel userModel)
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