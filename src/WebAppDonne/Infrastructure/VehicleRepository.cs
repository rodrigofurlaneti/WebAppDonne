using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleRepository : BaseRepository
    {
        #region Constructor

        public VehicleRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            try
            {
                this.logger.Trace("Vehicle_GetAll");
                commandText = "USP_VehicleGetAll";
                List<Vehicle> listVehicleModel = new List<Vehicle>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicle(sqlDataReader, listVehicleModel);
                    }
                }
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
                try
                {
                    this.logger.Trace("Vehicle_GetAllAsync");
                    commandText = "USP_VehicleGetAll";
                    List<Vehicle> listVehicleModel = new List<Vehicle>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListVehicle(sqlDataReader, listVehicleModel);
                        }
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("Vehicle_GetAllAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<Vehicle> GetByParked(int status)
        {
            try
            {
                commandText = "USP_VehicleGetParked";
                List<Vehicle> listVehicleModel = new List<Vehicle>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    GetVehicleParked(sqlCommand, status);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicle(sqlDataReader, listVehicleModel);
                    }
                }
                this.logger.Trace("Vehicle_GetByParked");
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_GetByParked");
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<Vehicle>> GetByParkedAsync(int status)
        {
                try
                {
                    commandText = "USP_VehicleGetByParked";
                    List<Vehicle> listVehicleModel = new List<Vehicle>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        GetVehicleParked(sqlCommand, status);
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListVehicle(sqlDataReader, listVehicleModel);
                        }
                    }
                    this.logger.Trace("Vehicle_GetByParkedAsync");
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("Vehicle_GetByParkedAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetByParked, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public Vehicle GetById(int id)
        {
            try
            {
                commandText = "USP_VehicleGetById";
                Vehicle vehicleModel = new Vehicle();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    GetSqlCommandVehicleById(sqlCommand, id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicle(sqlDataReader, vehicleModel);
                    }
                }
                this.logger.Trace("Vehicle_GetById");
                return vehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_GetById");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
                try
                {
                    this.logger.Trace("Vehicle_GetByIdAsync");
                    commandText = "USP_VehicleGetById";
                    Vehicle vehicleModel = new Vehicle();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        GetSqlCommandVehicleById(sqlCommand, id);
                        sqlConnection.Open();
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetVehicle(sqlDataReader, vehicleModel);
                        }
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    this.logger.TraceException("Vehicle_GetByIdAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetById, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(Vehicle vehicle)
        {
            try
            {
                commandText = "USP_VehicleInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleInsert(sqlCommand, vehicle);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("Vehicle_Insert");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_Insert");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleInsert, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task InsertAsync(Vehicle vehicle)
        {
            try
            {
                commandText = "USP_VehicleInsert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleInsert(sqlCommand, vehicle);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Vehicle_InsertAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_InsertAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleInsert, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int vehicleId)
        {
            try
            {
                commandText = "USP_VehicleDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleById(sqlCommand, vehicleId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("Vehicle_Delete");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_Delete");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleDelete, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task DeleteAsync(int vehicleId)
        {
            try
            {
                commandText = "USP_VehicleDelete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleById(sqlCommand, vehicleId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Vehicle_DeleteAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_DeleteAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleDelete, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(Vehicle vehicle)
        {
            try
            {
                commandText = "USP_VehicleUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleUpdate(sqlCommand, vehicle);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("Vehicle_Update");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_Update");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleUpdate, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            try
            {
                commandText = "USP_VehicleUpdate";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandVehicleUpdate(sqlCommand, vehicle);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Vehicle_UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Vehicle_UpdateAsync");
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleUpdate, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }
        #endregion

        #region Helpers
        private static void GetListVehicle(SqlDataReader sqlDataReader, List<Vehicle> listVehicle)
        {
            Vehicle vehicle = new Vehicle();
            GetVehicle(sqlDataReader, vehicle);
            listVehicle.Add(vehicle);
        }

        private static void GetVehicle(SqlDataReader sqlDataReader, Vehicle vehicle)
        {
            vehicle.VehicleId = Convert.ToInt32(sqlDataReader["VehicleId"]);
            vehicle.VehicleTypeId = Convert.ToInt32(sqlDataReader["VehicleTypeId"]);
            vehicle.VehicleTypeName = Convert.ToString(sqlDataReader["VehicleTypeName"]);
            vehicle.VehicleBrandId = Convert.ToInt32(sqlDataReader["VehicleBrandId"]);
            vehicle.VehicleBrandName = Convert.ToString(sqlDataReader["VehicleBrandName"]);
            vehicle.VehicleModelId = Convert.ToInt32(sqlDataReader["VehicleModelId"]);
            vehicle.VehicleModelName = Convert.ToString(sqlDataReader["VehicleModelName"]);
            vehicle.VehicleColorId = Convert.ToInt32(sqlDataReader["VehicleColorId"]);
            vehicle.VehicleColorName = Convert.ToString(sqlDataReader["VehicleColorName"]);
            vehicle.Plate = Convert.ToString(sqlDataReader["Plate"]);
            vehicle.EntryDate = Convert.ToString(sqlDataReader["EntryDate"]);
            vehicle.EntryTime = Convert.ToString(sqlDataReader["EntryTime"]);
            vehicle.DepartureDate = Convert.ToString(sqlDataReader["DepartureDate"]);
            vehicle.DepartureTime = Convert.ToString(sqlDataReader["DepartureTime"]);
            vehicle.Parked = Convert.ToInt32(sqlDataReader["Parked"]);
        }

        private static void GetVehicleParked(SqlCommand sqlCommand, int vehicle)
        {
            sqlCommand.Parameters.AddWithValue("@Parked", vehicle);
        }

        private static void GetSqlCommandVehicleById(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleId", id);
        }

        private static void GetSqlCommandVehicleInsert(SqlCommand sqlCommand, Vehicle vehicle)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
            sqlCommand.Parameters.AddWithValue("@VehicleTypeName", vehicle.VehicleTypeName);
            sqlCommand.Parameters.AddWithValue("@VehicleBrandId", vehicle.VehicleBrandId);
            sqlCommand.Parameters.AddWithValue("@VehicleBrandName", vehicle.VehicleBrandName);
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicle.VehicleModelId);
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicle.VehicleModelName);
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", vehicle.VehicleColorId);
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicle.VehicleColorName);
            sqlCommand.Parameters.AddWithValue("@Plate", vehicle.Plate);
            sqlCommand.Parameters.AddWithValue("@EntryDate", vehicle.EntryDate);
            sqlCommand.Parameters.AddWithValue("@EntryTime", vehicle.EntryTime);
            sqlCommand.Parameters.AddWithValue("@DepartureDate", vehicle.DepartureDate);
            sqlCommand.Parameters.AddWithValue("@DepartureTime", vehicle.DepartureTime);
            sqlCommand.Parameters.AddWithValue("@Parked", vehicle.Parked);
        }

        private static void GetSqlCommandVehicleUpdate(SqlCommand sqlCommand, Vehicle vehicle)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
            sqlCommand.Parameters.AddWithValue("@VehicleTypeId", vehicle.VehicleTypeId);
            sqlCommand.Parameters.AddWithValue("@VehicleTypeName", vehicle.VehicleTypeName);
            sqlCommand.Parameters.AddWithValue("@VehicleBrandId", vehicle.VehicleBrandId);
            sqlCommand.Parameters.AddWithValue("@VehicleBrandName", vehicle.VehicleBrandName);
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicle.VehicleModelId);
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicle.VehicleModelName);
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", vehicle.VehicleColorId);
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicle.VehicleColorName);
            sqlCommand.Parameters.AddWithValue("@Plate", vehicle.Plate);
            sqlCommand.Parameters.AddWithValue("@EntryDate", vehicle.EntryDate);
            sqlCommand.Parameters.AddWithValue("@EntryTime", vehicle.EntryTime);
            sqlCommand.Parameters.AddWithValue("@DepartureDate", vehicle.DepartureDate);
            sqlCommand.Parameters.AddWithValue("@DepartureTime", vehicle.DepartureTime);
            sqlCommand.Parameters.AddWithValue("@Parked", vehicle.Parked);
        }


        #endregion
    }
}