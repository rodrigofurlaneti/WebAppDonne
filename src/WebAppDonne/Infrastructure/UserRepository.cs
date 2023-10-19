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
            logger.Trace("GetAllUsers");
            List<UserModel> listUserModel = new List<UserModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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

        public UserModel GetById(int id)
        {
            logger.Trace("GetById");
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
            return User;
        }

        public UserModel GetByName(string Name)
        {
            logger.Trace("GetByName");
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
            return User;
        }

        public void Insert(UserModel User)
        {
            logger.Trace("Insert");
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
        }

        public void Delete(int UserId)
        {
            logger.Trace("Delete");
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_UserDelete", con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(UserModel User)
        {
            logger.Trace("Update");
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
        }

        #endregion
    }
}