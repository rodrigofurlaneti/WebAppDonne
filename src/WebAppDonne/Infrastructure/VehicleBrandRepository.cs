using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleBrandRepository : BaseRepository
    {
        #region Constructor

        public VehicleBrandRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleBrandModel> GetAllVehicleBrands()
        {
            try
            {
                commandText = "USP_VehicleBrandGetAll";
                List<VehicleBrandModel> listBrandModel = new List<VehicleBrandModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleBrandModel(sqlDataReader, listBrandModel);
                    }
                }
                logger.Trace("VehicleBrandGetAll");
                return listBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandsAsync()
        {
            commandText = "USP_VehicleBrandGetAll";
            List<VehicleBrandModel> listBrandModel = new List<VehicleBrandModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetAllBrandsAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleBrandModel(sqlDataReader, listBrandModel);
                    }
                    return listBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }
        
        public VehicleBrandModel GetById(int id)
        {
            try
            {
                commandText = "USP_VehicleBrandGetById";
                VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_VehicleBrandGetById", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@VehicleBrandId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleBrandModel(sqlDataReader, vehicleBrandModel);
                    }
                }
                logger.Trace("VehicleBrand_GetById");
                return vehicleBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrand_GetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<VehicleBrandModel> GetByIdAsync(int id)
        {
            commandText = "USP_VehicleBrandGetById";
            VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("USP_VehicleBrandGetById", sqlConnection))
                try
                {
                    logger.Trace("VehicleBrand_GetByIdAsync");
                    sqlCommand.Parameters.AddWithValue("@VehicleBrandId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleBrandModel(sqlDataReader, vehicleBrandModel);
                    }
                    return vehicleBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleBrandModel vehicleBrandModel)
        {
            commandText = "USP_VehicleBrandInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleBrandModelInsert(sqlCommand, vehicleBrandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleBrandModel vehicleBrandModel)
        {
            commandText = "USP_VehicleBrandInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_VehicleBrandInsert", sqlConnection);
            GetSqlCommandVehicleBrandModelInsert(sqlCommand, vehicleBrandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int brandId)
        {
            commandText = "USP_VehicleBrandDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleBrandModelDelete(sqlCommand, brandId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("VehicleBrand_Delete");
        }

        public async Task DeleteAsync(int brandId)
        {
            commandText = "USP_VehicleBrandDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleBrandModelDelete(sqlCommand, brandId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_DeleteAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Update(VehicleBrandModel vehicleBrandModel)
        {
            commandText = "USP_VehicleBrandUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleBrandModelUpdate(sqlCommand, vehicleBrandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("VehicleVehicle_Update");
        }

        public async Task UpdateAsync(VehicleBrandModel vehicleBrandModel)
        {
            commandText = "USP_VehicleBrandUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleBrandModelUpdate(sqlCommand, vehicleBrandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        #endregion

        #region Helpers

        private static void GetListVehicleBrandModel(SqlDataReader sqlDataReader, List<VehicleBrandModel> listVehicleBrandModel)
        {
            VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
            GetVehicleBrandModel(sqlDataReader, vehicleBrandModel);
            listVehicleBrandModel.Add(vehicleBrandModel);
        }

        private static void GetVehicleBrandModel(SqlDataReader sqlDataReader, VehicleBrandModel vehicleBrandModel)
        {
            vehicleBrandModel.VehicleBrandId = Convert.ToInt32(sqlDataReader["VehicleBrandId"]);
            vehicleBrandModel.VehicleBrandName = Convert.ToString(sqlDataReader["VehicleBrandName"]);
        }

        private static void GetSqlCommandVehicleBrandModelInsert(SqlCommand sqlCommand, VehicleBrandModel vehicleBrandModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
        }

        private static void GetSqlCommandVehicleBrandModelDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleBrandId", id);
        }

        private static void GetSqlCommandVehicleBrandModelUpdate(SqlCommand sqlCommand, VehicleBrandModel vehicleBrandModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleBrandId", vehicleBrandModel.VehicleBrandId);
            sqlCommand.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
        }

        #endregion
    }
}