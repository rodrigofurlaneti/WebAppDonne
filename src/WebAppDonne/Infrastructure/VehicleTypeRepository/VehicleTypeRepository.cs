using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure.VehicleTypeRepository
{
    public class VehicleTypeRepository : BaseRepository
    {
        #region Constructor

        public VehicleTypeRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleTypeModel> GetAll()
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
                logger.Trace("VehicleType_GetAll");
                return listVehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleTypeModel>> GetAllAsync()
        {
            try
            {
                commandText = "USP_VehicleTypeGetAll";
                List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    logger.Trace("VehicleType_GetAllAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleTypeModel(sqlDataReader, listVehicleTypeModel);
                    }
                }
                return listVehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_GetAllAsync");
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
                logger.Trace("VehicleType_GetById");
                return vehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_GetById");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<VehicleTypeModel> GetByIdAsync(int vehicleTypeId)
        {
            try
            {
                logger.Trace("VehicleType_GetByIdAsync");
                commandText = "USP_VehicleTypeGetById";
                VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleTypeModel(sqlDataReader, vehicleTypeModel);
                    }
                }

                return vehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetId, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                commandText = "USP_VehicleTypeInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelInsert(sqlCommand, vehicleTypeModel); sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleType_Insert");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_Insert");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeInsert, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task InsertAsync(VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                commandText = "USP_VehicleTypeInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelInsert(sqlCommand, vehicleTypeModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("VehicleType_InsertAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_InsertAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeInsert, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int vehicleTypeId)
        {
            try
            {
                commandText = "USP_VehicleTypeDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleType_Delete");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_Delete");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task DeleteAsync(int vehicleTypeId)
        {
            try
            {
                logger.Trace("VehicleType_DeleteAsync");
                commandText = "USP_VehicleTypeDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelById(sqlCommand, vehicleTypeId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeDelete, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                commandText = "USP_VehicleTypeUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelUpdate(sqlCommand, vehicleTypeModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleType_Update");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_Update");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeUpdate, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task UpdateAsync(VehicleTypeModel vehicleTypeModel)
        {
            try
            {
                commandText = "USP_VehicleTypeUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleTypeModelUpdate(sqlCommand, vehicleTypeModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("VehicleType_UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleType_UpdateAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeUpdate, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

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