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
                this.logger.Trace("VehicleBrand_GetAll");
                return listBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandsAsync()
        {
                try
                {
                    this.logger.Trace("VehicleBrand_GetAllAsync");
                    commandText = "USP_VehicleBrandGetAll";
                    List<VehicleBrandModel> listBrandModel = new List<VehicleBrandModel>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListVehicleBrandModel(sqlDataReader, listBrandModel);
                        }
                    }

                    return listBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleBrand_GetAllAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleBrandModel GetById(int id)
        {
            try
            {
                this.logger.Trace("VehicleBrand_GetById");
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

                return vehicleBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_GetById");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrand_GetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<VehicleBrandModel> GetByIdAsync(int id)
        {
                try
                {
                    this.logger.Trace("VehicleBrand_GetByIdAsync");
                    commandText = "USP_VehicleBrandGetById";
                    VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand("USP_VehicleBrandGetById", sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@VehicleBrandId", id);
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetVehicleBrandModel(sqlDataReader, vehicleBrandModel);
                        }
                    }
                    return vehicleBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("VehicleBrand_GetByIdAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleBrandModel vehicleBrandModel)
        {
            try
            {
                commandText = "USP_VehicleBrandInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleBrandModelInsert(sqlCommand, vehicleBrandModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("VehicleBrand_Insert");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_Insert");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandInsert, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task InsertAsync(VehicleBrandModel vehicleBrandModel)
        {
            try
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
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_InsertAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandInsert, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int brandId)
        {
            try
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
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_Delete");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task DeleteAsync(int brandId)
        {
            try
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
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandDelete, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(VehicleBrandModel vehicleBrandModel)
        {
            try
            {
                logger.Trace("VehicleBrand_Update");
                commandText = "USP_VehicleBrandUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleBrandModelUpdate(sqlCommand, vehicleBrandModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_Update");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandUpdate, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(VehicleBrandModel vehicleBrandModel)
        {
            try
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
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("VehicleBrand_UpdateAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandUpdate, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
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