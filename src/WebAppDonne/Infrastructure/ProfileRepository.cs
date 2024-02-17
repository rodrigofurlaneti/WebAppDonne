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
            commandText = "USP_Donne_Profile_GetAll";
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListProfileModel(sqlDataReader, listProfileModel);
                }
            }
            logger.Trace("Profile_GetAll");
            return listProfileModel;
        }

        public async Task<IEnumerable<ProfileModel>> GetAllProfilesAsync()
        {
            commandText = "USP_Donne_Profile_GetAll";
            List<ProfileModel> listProfileModel = new List<ProfileModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                    this.logger.Trace("Profile_GetAllAsync");
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListProfileModel(sqlDataReader, listProfileModel);
                    }
                return listProfileModel;
            }
            catch (Exception ex)
            {
                    string mensagem = "Erro ao consumir o metodo GetAllProfilesAsync " + ex.Message;
                    this.logger.TraceException("Profile_GetAllAsync");
                    throw new ArgumentNullException(mensagem);
            }
        }

        public ProfileModel GetById(int id)
        {
            commandText = "USP_Donne_Profile_GetById";
            ProfileModel profileModel = new ProfileModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProfileId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetProfileModel(sqlDataReader, profileModel);
                }
            }
            logger.Trace("Profile_GetById");
            return profileModel;
        }

        public async Task<ProfileModel> GetByIdAsync(int id)
        {
            try
            {
                commandText = "USP_Donne_Profile_GetById";
                ProfileModel profileModel = new ProfileModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ProfileId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetProfileModel(sqlDataReader, profileModel);
                    }
                }
                this.logger.Trace("Profile_GetByIdAsync");
                return profileModel;
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir o metodo GetAllProfilesAsync " + ex.Message;
                this.logger.TraceException("Profile_GetByIdAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Insert(ProfileModel profileModel)
        {
            commandText = "USP_Donne_Profile_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandProfileModelInsert(sqlCommand, profileModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Profile_Insert");
        }

        public async Task InsertAsync(ProfileModel profileModel)
        {
            try
            {
                commandText = "USP_Donne_Profile_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandProfileModelInsert(sqlCommand, profileModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Profile_InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir o metodo InsertAsync " + ex.Message;
                this.logger.TraceException("Profile_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Delete(int ProfileId)
        {
            commandText = "USP_Donne_Profile_Delete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ProfileId", ProfileId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Profile_Delete");
        }

        public async Task DeleteAsync(int ProfileId)
        {
            try
            {
                commandText = "USP_Donne_Profile_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProfileId", ProfileId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Profile_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir o metodo DeleteAsync " + ex.Message;
                this.logger.TraceException("Profile_DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Update(ProfileModel profileModel)
        {
            commandText = "USP_Donne_Profile_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandProfileModelUpdate(sqlCommand, profileModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Profile_Update");
        }

        public async Task UpdateAsync(ProfileModel profileModel)
        {
            try
            {
                commandText = "USP_Donne_Profile_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandProfileModelUpdate(sqlCommand, profileModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Profile_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir o metodo UpdateAsync " + ex.Message;
                this.logger.TraceException("Profile_UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        #endregion

        #region Helpers
        private List<ProfileModel> GetListProfileModel(SqlDataReader sqlDataReader, List<ProfileModel> listProfileModel)
        {
            ProfileModel profileModel = new ProfileModel();
            profileModel = GetProfileModel(sqlDataReader, profileModel);
            listProfileModel.Add(profileModel);
            return listProfileModel;
        }

        private ProfileModel GetProfileModel(SqlDataReader sqlDataReader, ProfileModel profileModel)
        {
            profileModel.ProfileId = Convert.ToInt32(sqlDataReader["ProfileId"]);
            profileModel.ProfileName = Convert.ToString(sqlDataReader["ProfileName"]);
            profileModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            profileModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            profileModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            profileModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            return profileModel;
        }

        private void GetSqlCommandProfileModelInsert(SqlCommand sqlCommand, ProfileModel profileModel)
        {
            sqlCommand.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", profileModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", profileModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", profileModel.UserName);
        }

        private void GetSqlCommandProfileModelUpdate(SqlCommand sqlCommand, ProfileModel profileModel)
        {
            sqlCommand.Parameters.AddWithValue("@ProfileId", profileModel.ProfileId);
            sqlCommand.Parameters.AddWithValue("@ProfileName", profileModel.ProfileName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", profileModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", profileModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", profileModel.UserName);
        }
        #endregion
    }
}
