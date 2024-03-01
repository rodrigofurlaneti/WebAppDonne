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
                        listVehicleModel = GetListVehicle(sqlDataReader, listVehicleModel);
                    }
                }
                logger.Trace("GetAllVehicles");
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            commandText = "USP_VehicleGetAll";
            List<Vehicle> listVehicleModel = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("VehicleGetAll");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        listVehicleModel = GetListVehicle(sqlDataReader, listVehicleModel);
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
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
                logger.Trace("GetByStatus");
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<Vehicle>> GetByParkedAsync(int status)
        {
            commandText = "USP_VehicleGetParked";
            List<Vehicle> listVehicleModel = new List<Vehicle>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetByParkedAsync");
                    GetVehicleParked(sqlCommand, status);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicle(sqlDataReader, listVehicleModel);
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
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
                logger.Trace("GetById");
                return vehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            commandText = "USP_VehicleGetById";
            Vehicle vehicleModel = new Vehicle();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetByIdAsync");
                    GetSqlCommandVehicleById(sqlCommand, id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicle(sqlDataReader, vehicleModel);
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(Vehicle vehicle)
        {
            commandText = "USP_VehicleInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleInsert(sqlCommand, vehicle);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(Vehicle vehicle)
        {
            commandText = "USP_VehicleInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleInsert(sqlCommand, vehicle);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int vehicleId)
        {
            commandText = "USP_VehicleDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleById(sqlCommand, vehicleId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int vehicleId)
        {
            commandText = "USP_VehicleBrandDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleById(sqlCommand, vehicleId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Update(Vehicle vehicle)
        {
            commandText = "USP_VehicleBrandUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleUpdate(sqlCommand, vehicle);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            commandText = "USP_VehicleBrandUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleUpdate(sqlCommand, vehicle);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }
        #endregion

        #region Helpers
        private List<Vehicle> GetListVehicle(SqlDataReader sqlDataReader, List<Vehicle> listVehicle)
        {
            Vehicle vehicle = new Vehicle();
            vehicle = GetVehicle(sqlDataReader, vehicle);
            listVehicle.Add(vehicle);
            return listVehicle;
        }

        private Vehicle GetVehicle(SqlDataReader sqlDataReader, Vehicle vehicle)
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
            return vehicle;
        }

        private void GetVehicleParked(SqlCommand sqlCommand, int vehicle)
        {
            sqlCommand.Parameters.AddWithValue("@Parked", vehicle);
        }

        private void GetSqlCommandVehicleById(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleId", id);
        }

        private void GetSqlCommandVehicleInsert(SqlCommand sqlCommand, Vehicle vehicle)
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

        private void GetSqlCommandVehicleUpdate(SqlCommand sqlCommand, Vehicle vehicle)
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
            sqlCommand.Parameters.AddWithValue("@Parked", vehicle.Parked); ;
        }


        #endregion
    }
}