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
                List<Vehicle> listVehicleModel = new List<Vehicle>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Vehicle vehicleModel = new Vehicle();
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
                        listVehicleModel.Add(vehicleModel);
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
            List<Vehicle> listVehicleModel = new List<Vehicle>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleGetAll", con))
                try
                {
                    logger.Trace("VehicleGetAll");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Vehicle vehicleModel = new Vehicle();
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
                        listVehicleModel.Add(vehicleModel);
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<Vehicle> GetByStatus(int status)
        {
            try
            {
                List<Vehicle> listVehicleModel = new List<Vehicle>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Vehicle vehicleModel = new Vehicle();
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
                        listVehicleModel.Add(vehicleModel);
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

        public async Task<IEnumerable<Vehicle>> GetByStatusAsync(int status)
        {
            List<Vehicle> listVehicleModel = new List<Vehicle>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Vehicle vehicleModel = new Vehicle();
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
                        listVehicleModel.Add(vehicleModel);
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public Vehicle GetById(int id)
        {
            try
            {
                Vehicle vehicleModel = new Vehicle();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleGetById", con);
                    cmd.Parameters.AddWithValue("@VehicleId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
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
            Vehicle vehicleModel = new Vehicle();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@VehicleId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        vehicleModel = GetVehicleModel(vehicleModel, rdr);
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(Vehicle vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleModel.VehicleBrandName);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleModel.VehicleColorName);
            cmd.Parameters.AddWithValue("@Plate", vehicleModel.Plate);
            cmd.Parameters.AddWithValue("@EntryDate", vehicleModel.EntryDate);
            cmd.Parameters.AddWithValue("@EntryTime", vehicleModel.EntryTime);
            cmd.Parameters.AddWithValue("@DepartureDate", vehicleModel.DepartureDate);
            cmd.Parameters.AddWithValue("@DepartureTime", vehicleModel.DepartureTime);
            cmd.Parameters.AddWithValue("@Parked", vehicleModel.Parked);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(Vehicle vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleModel.VehicleBrandName);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleModel.VehicleColorName);
            cmd.Parameters.AddWithValue("@Plate", vehicleModel.Plate);
            cmd.Parameters.AddWithValue("@EntryDate", vehicleModel.EntryDate);
            cmd.Parameters.AddWithValue("@EntryTime", vehicleModel.EntryTime);
            cmd.Parameters.AddWithValue("@DepartureDate", vehicleModel.DepartureDate);
            cmd.Parameters.AddWithValue("@DepartureTime", vehicleModel.DepartureTime);
            cmd.Parameters.AddWithValue("@Parked", vehicleModel.Parked);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int VehicleId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleDelete", con);
            cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int VehicleId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleDelete", con);
            cmd.Parameters.AddWithValue("@VehicleId", VehicleId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(Vehicle vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleModel.VehicleBrandName);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleModel.VehicleColorName);
            cmd.Parameters.AddWithValue("@Plate", vehicleModel.Plate);
            cmd.Parameters.AddWithValue("@EntryDate", vehicleModel.EntryDate);
            cmd.Parameters.AddWithValue("@EntryTime", vehicleModel.EntryTime);
            cmd.Parameters.AddWithValue("@DepartureDate", vehicleModel.DepartureDate);
            cmd.Parameters.AddWithValue("@DepartureTime", vehicleModel.DepartureTime);
            cmd.Parameters.AddWithValue("@Parked", vehicleModel.Parked);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(Vehicle vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleModel.VehicleBrandName);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleModel.VehicleColorName);
            cmd.Parameters.AddWithValue("@Plate", vehicleModel.Plate);
            cmd.Parameters.AddWithValue("@EntryDate", vehicleModel.EntryDate);
            cmd.Parameters.AddWithValue("@EntryTime", vehicleModel.EntryTime);
            cmd.Parameters.AddWithValue("@DepartureDate", vehicleModel.DepartureDate);
            cmd.Parameters.AddWithValue("@DepartureTime", vehicleModel.DepartureTime);
            cmd.Parameters.AddWithValue("@Parked", vehicleModel.Parked);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public Vehicle GetVehicleModel(Vehicle vehicleModel, SqlDataReader rdr)
        {
            vehicleModel.VehicleId = Convert.ToInt32(rdr["VehicleId"]);
            vehicleModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
            vehicleModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
            vehicleModel.VehicleBrandId = Convert.ToInt32(rdr["VehicleBrandId"]);
            vehicleModel.VehicleBrandName = Convert.ToString(rdr["VehicleBrandName"]);
            vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
            vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
            vehicleModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
            vehicleModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
            vehicleModel.Plate = Convert.ToString(rdr["Plate"]);
            vehicleModel.EntryDate = Convert.ToString(rdr["EntryDate"]);
            vehicleModel.EntryTime = Convert.ToString(rdr["EntryTime"]);
            vehicleModel.DepartureDate = Convert.ToString(rdr["DepartureDate"]);
            vehicleModel.DepartureTime = Convert.ToString(rdr["DepartureTime"]);
            vehicleModel.Parked = Convert.ToInt32(rdr["Parked"]);
            return vehicleModel;
        }

        #endregion
    }
}