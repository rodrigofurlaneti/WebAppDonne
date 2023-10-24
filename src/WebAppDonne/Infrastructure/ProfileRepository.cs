using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class ProfileRepository : BaseRepository
    {
        #region Constructor

        public ProfileRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

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
            logger.Trace("GetAllProfiles");
            return listProfileModel;
        }

        public async Task<IEnumerable<ProfileModel>> GetAllProfilesAsync()
        {
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                    SqlCommand cmd = new SqlCommand("USP_ProfileGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
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
                this.logger.Trace("GetAllProfilesAsync");
                return listProfileModel;
            }
            catch (ArgumentNullException ex)
            {
                    string mensagem = "Erro ao consumir o metodo GetAllProfilesAsync " + ex.Message;
                    this.logger.TraceException("GetProductAsync");
                    throw new ArgumentNullException(mensagem);
            }
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
            logger.Trace("GetById");
            return profileModel;
        }

        public async Task<ProfileModel> GetByIdAsync(int id)
        {
            try
            {
                ProfileModel profileModel = new ProfileModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ProfileGetById", con);
                    cmd.Parameters.AddWithValue("@ProfileId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
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
                logger.Trace("GetByIdAsync");
                return profileModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir o metodo GetAllProfilesAsync " + ex.Message;
                this.logger.TraceException("GetById");
                throw new ArgumentNullException(mensagem);
            }
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
            logger.Trace("Insert");
        }

        public async Task InsertAsync(ProfileModel profileModel)
        {
            try
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
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("InsertAsync");
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir o metodo InsertAsync " + ex.Message;
                this.logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
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
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int ProfileId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_ProfileDelete", con);
                cmd.Parameters.AddWithValue("@ProfileId", ProfileId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("DeleteAsync");
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir o metodo DeleteAsync " + ex.Message;
                this.logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
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
            logger.Trace("Update");
        }

        public async Task UpdateAsync(ProfileModel profileModel)
        {
            try
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
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                logger.Trace("UpdateAsync");
            }
            catch (ArgumentNullException ex)
            {
                string mensagem = "Erro ao consumir o metodo UpdateAsync " + ex.Message;
                this.logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        #endregion
    }
}
