using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class ProfileRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public ProfileRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<ProfileModel> GetAllProfiles()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileUserGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProfileModel Profile = new ProfileModel();
                    Profile.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    Profile.ProfileName = Convert.ToString(rdr["ProfileName"]);
                    listProfileModel.Add(Profile);
                }
            }
            return listProfileModel;
        }

        public ProfileModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            ProfileModel Profile = new ProfileModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProfileUserGetById", con);
                cmd.Parameters.AddWithValue("@ProfileId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Profile.ProfileId = Convert.ToInt32(rdr["ProfileId"]);
                    Profile.ProfileName = Convert.ToString(rdr["ProfileName"]);
                }
            }
            return Profile;
        }

        public void Insert(ProfileModel Profile)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileUserInsert", con);
            cmd.Parameters.AddWithValue("@ProfileName", Profile.ProfileName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int ProfileId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileUserDelete", con);
            cmd.Parameters.AddWithValue("@ProfileId", ProfileId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(ProfileModel Profile)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProfileUserUpdate", con);
            cmd.Parameters.AddWithValue("@ProfileId", Profile.ProfileId);
            cmd.Parameters.AddWithValue("@ProfileName", Profile.ProfileName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
