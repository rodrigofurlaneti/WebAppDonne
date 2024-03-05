using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure.VehicleColor
{
    public class VehicleColorRepository : BaseRepository, IVehicleColorRepository
    {
        #region Constructor

        public VehicleColorRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleColorModel> GetAll()
        {
            try
            {
                commandText = "USP_VehicleColorGetAll";
                List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleColorModel(sqlDataReader, listColorModel);
                    }
                }
                logger.Trace("VehicleColor_GetAll");
                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleColorModel>> GetAllAsync()
        {
            try
            {
                commandText = "USP_VehicleColorGetAll";
                List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    logger.Trace("VehicleColor_GetAllAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleColorModel(sqlDataReader, listColorModel);
                    }
                }

                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_GetAllAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public VehicleColorModel GetById(int id)
        {
            try
            {
                commandText = "USP_VehicleColorGetById";
                VehicleColorModel vehicleColorModel = new VehicleColorModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleColorModel(sqlDataReader, vehicleColorModel);
                    }
                }
                logger.Trace("VehicleColor_GetById");
                return vehicleColorModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_GetById");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleColorModel> GetByIdAsync(int id)
        {
            try
            {
                logger.Trace("VehicleColor_GetByIdAsync");
                commandText = "USP_VehicleColorGetById";
                VehicleColorModel vehicleColorModel = new VehicleColorModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleColorModel(sqlDataReader, vehicleColorModel);
                    }
                }

                return vehicleColorModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_GetByIdAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetId, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(VehicleColorModel vehicleColorModel)
        {
            try
            {
                commandText = "USP_VehicleColorInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelInsert(sqlCommand, vehicleColorModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleColor_Insert");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_Insert");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorInsert, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
;
        }

        public async Task InsertAsync(VehicleColorModel vehicleColorModel)
        {
            try
            {
                commandText = "USP_VehicleColorInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelInsert(sqlCommand, vehicleColorModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("VehicleColor_InsertAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_InsertAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorInsert, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int vehicleColorId)
        {
            try
            {
                commandText = "USP_VehicleColorDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelDelete(sqlCommand, vehicleColorId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleColor_Delete");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_Delete");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task DeleteAsync(int vehicleColorId)
        {
            try
            {
                commandText = "USP_VehicleColorDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelDelete(sqlCommand, vehicleColorId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("VehicleColor_DeleteAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorDelete, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(VehicleColorModel vehicleColorModel)
        {
            try
            {
                commandText = "USP_VehicleColorUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelUpdate(sqlCommand, vehicleColorModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleColor_Update");
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_Update");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorUpdate, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(VehicleColorModel vehicleColorModel)
        {
            try
            {
                commandText = "USP_VehicleColorUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleColorModelUpdate(sqlCommand, vehicleColorModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("VehicleColor_UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("VehicleColor_UpdateAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorUpdate, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers

        private static void GetListVehicleColorModel(SqlDataReader sqlDataReader, List<VehicleColorModel> listVehicleColorModel)
        {
            VehicleColorModel vehicleColorModel = new VehicleColorModel();
            GetVehicleColorModel(sqlDataReader, vehicleColorModel);
            listVehicleColorModel.Add(vehicleColorModel);
        }

        private static void GetVehicleColorModel(SqlDataReader sqlDataReader, VehicleColorModel vehicleColorModel)
        {
            vehicleColorModel.VehicleColorId = Convert.ToInt32(sqlDataReader["VehicleColorId"]);
            vehicleColorModel.VehicleColorName = Convert.ToString(sqlDataReader["VehicleColorName"]);
        }

        private static void GetSqlCommandVehicleColorModelInsert(SqlCommand sqlCommand, VehicleColorModel vehicleColorModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
        }

        private static void GetSqlCommandVehicleColorModelDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
        }

        private static void GetSqlCommandVehicleColorModelUpdate(SqlCommand sqlCommand, VehicleColorModel vehicleColorModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", vehicleColorModel.VehicleColorId);
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
        }

        #endregion
    }
}