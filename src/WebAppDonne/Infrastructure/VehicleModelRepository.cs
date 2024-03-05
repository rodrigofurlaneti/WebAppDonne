using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleModelRepository : BaseRepository
    {
        #region Constructor

        public VehicleModelRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleModel> GetAllVehicleModels()
        {
            try
            {
                this.logger.Trace("VehicleModel_GetAll");
                commandText = "USP_VehicleModelGetAll";
                List<VehicleModel> listVehicleModel = new List<VehicleModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleModel(sqlDataReader, listVehicleModel);
                    }
                }
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
                try
                {
                    this.logger.Trace("VehicleModel_GetAllAsync");
                    commandText = "USP_VehicleModelGetAll";
                    List<VehicleModel> listVehicleModel = new List<VehicleModel>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListVehicleModel(sqlDataReader, listVehicleModel);
                        }
                    }

                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleModel_GetAllAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleModel GetById(int id)
        {
            try
            {
                this.logger.Trace("VehicleModel_GetById");
                commandText = "USP_VehicleModelGetAll";
                VehicleModel vehicleModel = new VehicleModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_VehicleModelGetById", sqlConnection);
                    GetSqlCommandVehicleModelById(sqlCommand, id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleModel(sqlDataReader, vehicleModel);
                    }
                }
                return vehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_GetById");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
                try
                {
                    this.logger.Trace("VehicleModel_GetByIdAsync");
                    commandText = "USP_VehicleModelGetAll";
                    VehicleModel vehicleModel = new VehicleModel();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand("USP_VehicleModelGetById", sqlConnection))
                    {
                        GetSqlCommandVehicleModelById(sqlCommand, id);
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetVehicleModel(sqlDataReader, vehicleModel);
                        }
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleModel_GetByIdAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleModel vehicleModel)
        {
            try
            {
                commandText = "USP_VehicleModelInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelInsert(sqlCommand, vehicleModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                this.logger.Trace("VehicleModel_Insert");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_Insert");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelInsert, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            try
            {
                commandText = "USP_VehicleModelInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelInsert(sqlCommand, vehicleModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                this.logger.Trace("VehicleModel_InsertAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_InsertAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelInsert, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int vehicleModelId)
        {
            try
            {
                commandText = "USP_VehicleModelDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelById(sqlCommand, vehicleModelId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                this.logger.Trace("VehicleModel_Delete");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_Delete");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task DeleteAsync(int vehicleModelId)
        {
            try
            {
                commandText = "USP_VehicleModelDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelById(sqlCommand, vehicleModelId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                this.logger.Trace("VehicleModel_DeleteAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(VehicleModel vehicleModel)
        {
            try
            {
                this.logger.Trace("VehicleModel_Update");
                commandText = "USP_VehicleModelUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelUpdate(sqlCommand, vehicleModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_Update");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelUpdate, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            try
            {
                commandText = "USP_VehicleModelUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleModelUpdate(sqlCommand, vehicleModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                this.logger.Trace("VehicleModel_UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleModel_UpdateAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelUpdate, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion

        #region Helpers

        private static void GetListVehicleModel(SqlDataReader sqlDataReader, List<VehicleModel> listVehicleModel)
        {
            VehicleModel vehicleModel = new VehicleModel();
            GetVehicleModel(sqlDataReader, vehicleModel);
            listVehicleModel.Add(vehicleModel);
        }

        private static void GetVehicleModel(SqlDataReader sqlDataReader, VehicleModel vehicleModel)
        {
            vehicleModel.VehicleModelId = Convert.ToInt32(sqlDataReader["VehicleModelId"]);
            vehicleModel.VehicleModelName = Convert.ToString(sqlDataReader["VehicleModelName"]);
        }

        private static void GetSqlCommandVehicleModelById(SqlCommand sqlCommand, int vehicleModelId)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicleModelId);
        }

        private static void GetSqlCommandVehicleModelInsert(SqlCommand sqlCommand, VehicleModel vehicleModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
        }

        private static void GetSqlCommandVehicleModelUpdate(SqlCommand sqlCommand, VehicleModel vehicleModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
        }


        #endregion

    }
}