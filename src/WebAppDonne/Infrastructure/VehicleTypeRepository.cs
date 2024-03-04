using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleTypeRepository : BaseRepository
    {
        #region Constructor

        public VehicleTypeRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleTypeModel> GetAllVehicleTypes()
        {
            try
            {
                commandText = "USP_VehicleTypeGetAll";
                List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleTypeModel(sqlDataReader, listVehicleTypeModel);
                    }
                }
                this.logger.Trace("VehicleType_GetAllAsync");
                return listVehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleType_GetAllAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleTypeModel>> GetAllVehicleTypesAsync()
        {
            commandText = "USP_VehicleTypeGetAll";
            List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    this.logger.Trace("VehicleType_GetAllAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleTypeModel(sqlDataReader, listVehicleTypeModel);
                    }
                    return listVehicleTypeModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleType_GetAllAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleTypeModel GetById(int vehicleTypeId)
        {
            try
            {
                commandText = "USP_VehicleTypeGetById";
                VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleTypeModel(sqlDataReader, vehicleTypeModel);
                    }
                }
                this.logger.Trace("VehicleType_GetByIdAsync");
                return vehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleType_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<VehicleTypeModel> GetByIdAsync(int vehicleTypeId)
        {
            commandText = "USP_VehicleTypeGetById";
            VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    this.logger.Trace("VehicleType_GetByIdAsync");
                    GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleTypeModel(sqlDataReader, vehicleTypeModel);
                    }
                    return vehicleTypeModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleType_GetByIdAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleTypeModel vehicleTypeModel)
        {
            commandText = "USP_VehicleTypeInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelInsert(sqlCommand, vehicleTypeModel); sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            this.logger.Trace("VehicleType_InsertAsync");
        }

        public async Task InsertAsync(VehicleTypeModel vehicleTypeModel)
        {
            commandText = "USP_VehicleTypeInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelInsert(sqlCommand, vehicleTypeModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            this.logger.Trace("VehicleType_InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int vehicleTypeId)
        {
            commandText = "USP_VehicleTypeDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            this.logger.Trace("VehicleType_Delete");
        }

        public async Task DeleteAsync(int vehicleTypeId)
        {
            commandText = "USP_VehicleTypeDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            this.logger.Trace("VehicleType_DeleteAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Update(VehicleTypeModel vehicleTypeModel)
        {
            commandText = "USP_VehicleTypeUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelUpdate(sqlCommand, vehicleTypeModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            this.logger.Trace("VehicleType_Update");
        }

        public async Task UpdateAsync(VehicleTypeModel vehicleTypeModel)
        {
            commandText = "USP_VehicleTypeUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleTypeModelUpdate(sqlCommand, vehicleTypeModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            this.logger.Trace("VehicleType_UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        #endregion

        #region Helpers
        private static void GetListVehicleTypeModel(SqlDataReader sqlDataReader, List<VehicleTypeModel> listVehicleTypeModel)
        {
            VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
            GetVehicleTypeModel(sqlDataReader, vehicleTypeModel);
            listVehicleTypeModel.Add(vehicleTypeModel);
        }

        private static void GetVehicleTypeModel(SqlDataReader sqlDataReader, VehicleTypeModel vehicleTypeModel)
        {
            vehicleTypeModel.VehicleTypeId = Convert.ToInt32(sqlDataReader["VehicleTypeId"]);
            vehicleTypeModel.VehicleTypeName = Convert.ToString(sqlDataReader["VehicleTypeName"]);
        }

        private static void GetSqlCommandVehicleTypeModelById(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleTypeId", id);
        }

        private static void GetSqlCommandVehicleTypeModelInsert(SqlCommand sqlCommand, VehicleTypeModel vehicleTypeModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
        }

        private static void GetSqlCommandVehicleTypeModelUpdate(SqlCommand sqlCommand, VehicleTypeModel vehicleTypeModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeModel.VehicleTypeId);
            sqlCommand.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
        }


        #endregion
    }
}