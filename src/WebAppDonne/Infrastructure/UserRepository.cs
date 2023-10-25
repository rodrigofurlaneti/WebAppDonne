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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                logger.Trace("GetAllUsers");
                SqlCommand cmd = new SqlCommand("USP_UserGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserModel User = new UserModel();
                    User.UserId = Convert.ToInt32(rdr["UserId"]);
                    User.UserName = Convert.ToString(rdr["UserName"]);
                    User.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    User.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    User.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    User.Status = Convert.ToBoolean(rdr["Status"]);
                    listUserModel.Add(User);
                }
            }
            return listUserModel;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                this.logger.Trace("GetAllUserAsync");
                SqlCommand cmd = new SqlCommand("USP_UserGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    UserModel User = new UserModel();
                    User.UserId = Convert.ToInt32(rdr["UserId"]);
                    User.UserName = Convert.ToString(rdr["UserName"]);
                    User.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    User.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    User.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    User.Status = Convert.ToBoolean(rdr["Status"]);
                    listUserModel.Add(User);
                }
                return listUserModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetUserAsync " + ex.Message;
                this.logger.TraceException("GetAllUserAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public UserModel GetById(int id)
        {
            UserModel User = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_UserGetById", con);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User.UserId = Convert.ToInt32(rdr["UserId"]);
                    User.UserName = Convert.ToString(rdr["UserName"]);
                    User.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    User.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    User.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    User.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            logger.Trace("GetById");
            return User;
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            UserModel userModel = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                this.logger.Trace("GetByIdAsync");
                SqlCommand cmd = new SqlCommand("USP_UserGetById", con);
                cmd.Parameters.AddWithValue("@UserId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    userModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    userModel.UserName = Convert.ToString(rdr["UserName"]);
                    userModel.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    userModel.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    userModel.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    userModel.Status = Convert.ToBoolean(rdr["Status"]);
                }
                return userModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByIdAsync " + ex.Message;
                this.logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public UserModel GetByName(string Name)
        {
            UserModel User = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_UserGetByName", con);
                cmd.Parameters.AddWithValue("@UserName", Name);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    User.UserId = Convert.ToInt32(rdr["UserId"]);
                    User.UserName = Convert.ToString(rdr["UserName"]);
                    User.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    User.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    User.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    User.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            logger.Trace("GetByName");
            return User;
        }


        public async Task<UserModel> GetByNameAsync(string Name)
        {
            UserModel user = new UserModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                logger.Trace("GetByNameAsync");
                SqlCommand cmd = new SqlCommand("USP_UserGetByName", con);
                cmd.Parameters.AddWithValue("@UserName", Name);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    user.UserId = Convert.ToInt32(rdr["UserId"]);
                    user.UserName = Convert.ToString(rdr["UserName"]);
                    user.UserPassword = Convert.ToString(rdr["UserPassword"]);
                    user.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    user.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    user.Status = Convert.ToBoolean(rdr["Status"]);
                }
                return user;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota GetByNameAsync " + ex.Message;
                this.logger.TraceException("GetByNameAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Insert(UserModel User)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_UserInsert", con);
            cmd.Parameters.AddWithValue("@UserName", User.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", User.UserPassword);
            cmd.Parameters.AddWithValue("@ProfileId", User.ProfileId);
            cmd.Parameters.AddWithValue("@ProfileName", User.ProfileName);
            cmd.Parameters.AddWithValue("@Status", User.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(UserModel User)
        {
            try
            {
                logger.Trace("InsertAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_UserInsert", con);
                cmd.Parameters.AddWithValue("@UserName", User.UserName);
                cmd.Parameters.AddWithValue("@UserPassword", User.UserPassword);
                cmd.Parameters.AddWithValue("@ProfileId", User.ProfileId);
                cmd.Parameters.AddWithValue("@ProfileName", User.ProfileName);
                cmd.Parameters.AddWithValue("@Status", User.Status);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
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
            SqlCommand cmd = new SqlCommand("USP_UserDelete", con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int UserId)
        {
            try
            {
                logger.Trace("DeleteAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_UserDelete", con);
                cmd.Parameters.AddWithValue("@UserId", UserId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota DeleteAsync " + ex.Message;
                this.logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Update(UserModel User)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_UserUpdate", con);
            cmd.Parameters.AddWithValue("@UserId", User.UserId);
            cmd.Parameters.AddWithValue("@UserName", User.UserName);
            cmd.Parameters.AddWithValue("@UserPassword", User.UserPassword);
            cmd.Parameters.AddWithValue("@ProfileId", User.ProfileId);
            cmd.Parameters.AddWithValue("@ProfileName", User.ProfileName);
            cmd.Parameters.AddWithValue("@Status", User.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(UserModel User)
        {
            try
            {
                logger.Trace("UpdateAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_UserUpdate", con);
                cmd.Parameters.AddWithValue("@UserId", User.UserId);
                cmd.Parameters.AddWithValue("@UserName", User.UserName);
                cmd.Parameters.AddWithValue("@UserPassword", User.UserPassword);
                cmd.Parameters.AddWithValue("@ProfileId", User.ProfileId);
                cmd.Parameters.AddWithValue("@ProfileName", User.ProfileName);
                cmd.Parameters.AddWithValue("@Status", User.Status);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a controler User, rota UpdateAsync " + ex.Message;
                this.logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        #endregion
    }
}