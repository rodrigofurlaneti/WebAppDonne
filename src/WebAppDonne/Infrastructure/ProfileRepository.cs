using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class ProfileRepository : BaseRepository
    {
        #region Constructor
        public ProfileRepository() : base() { }
        #endregion

        #region Methods 

        public IEnumerable<ProfileModel> GetAllProfiles()
        {
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProfileModel profileModel = new ProfileModel();
                    profileModel.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    profileModel.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    profileModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    profileModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    profileModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    profileModel.UserName = Convert.ToString(rdr["UserName"]);
                    listProfileModel.Add(profileModel);
                }
            }
            return listProfileModel;
        }

        public ProfileModel GetById(int id)
        {
            ProfileModel profileModel = new ProfileModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileGetById", con);
                cmd.Parameters.AddWithValue("@ProfileId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    profileModel.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    profileModel.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    profileModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    profileModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    profileModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    profileModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            return profileModel;
        }

        public void Insert(ProfileModel profileModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileInsert", con);
            cmd.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", profileModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", profileModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int ProfileId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileDelete", con);
            cmd.Parameters.AddWithValue("@ProfileId", ProfileId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(ProfileModel profileModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileUpdate", con);
            cmd.Parameters.AddWithValue("@ProfileId", profileModel.ProfileId);
            cmd.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            cmd.Parameters.AddWithValue("@DateInsert", profileModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", profileModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", profileModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
