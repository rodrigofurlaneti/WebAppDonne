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

        public IEnumerable<VehicleModel> GetAllVehicles()
        {
            try
            {
                List<VehicleModel> listVehicleModel = new List<VehicleModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
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

        public async Task<IEnumerable<VehicleModel>> GetAllVehiclesAsync()
        {
            List<VehicleModel> listVehicleModel = new List<VehicleModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleGetAll", con))
                try
                {
                    logger.Trace("GetAllVehiclesAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
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

        public IEnumerable<VehicleModel> GetByStatus(int status)
        {
            try
            {
                List<VehicleModel> listVehicleModel = new List<VehicleModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
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

        public async Task<IEnumerable<VehicleModel>> GetByStatusAsync(int status)
        {
            List<VehicleModel> listVehicleModel = new List<VehicleModel>();
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
                        VehicleModel vehicleModel = new VehicleModel();
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

        public VehicleModel GetById(int id)
        {
            try
            {
                VehicleModel vehicleModel = new VehicleModel();
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

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            VehicleModel vehicleModel = new VehicleModel();
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

        public void Insert(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@BrandId", vehicleModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", vehicleModel.BrandName);
            cmd.Parameters.AddWithValue("@ModelId", vehicleModel.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", vehicleModel.ModelName);
            cmd.Parameters.AddWithValue("@ColorId", vehicleModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", vehicleModel.ColorName);
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

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@BrandId", vehicleModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", vehicleModel.BrandName);
            cmd.Parameters.AddWithValue("@ModelId", vehicleModel.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", vehicleModel.ModelName);
            cmd.Parameters.AddWithValue("@ColorId", vehicleModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", vehicleModel.ColorName);
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

        public void Update(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@BrandId", vehicleModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", vehicleModel.BrandName);
            cmd.Parameters.AddWithValue("@ModelId", vehicleModel.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", vehicleModel.ModelName);
            cmd.Parameters.AddWithValue("@ColorId", vehicleModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", vehicleModel.ColorName);
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

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleModel.VehicleTypeName);
            cmd.Parameters.AddWithValue("@BrandId", vehicleModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", vehicleModel.BrandName);
            cmd.Parameters.AddWithValue("@ModelId", vehicleModel.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", vehicleModel.ModelName);
            cmd.Parameters.AddWithValue("@ColorId", vehicleModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", vehicleModel.ColorName);
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

        public VehicleModel GetVehicleModel(VehicleModel vehicleModel, SqlDataReader rdr)
        {
            vehicleModel.VehicleId = Convert.ToInt32(rdr["VehicleId"]);
            vehicleModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
            vehicleModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
            vehicleModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
            vehicleModel.BrandName = Convert.ToString(rdr["BrandName"]);
            vehicleModel.ModelId = Convert.ToInt32(rdr["ModelId"]);
            vehicleModel.ModelName = Convert.ToString(rdr["ModelName"]);
            vehicleModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
            vehicleModel.ColorName = Convert.ToString(rdr["ColorName"]);
            vehicleModel.Plate = Convert.ToString(rdr["Plate"]);
            vehicleModel.EntryDate = Convert.ToString(rdr["EntryDate"]);
            vehicleModel.EntryTime = Convert.ToString(rdr["EntryTime"]);
            vehicleModel.DepartureDate = Convert.ToString(rdr["DepartureDate"]);
            vehicleModel.DepartureTime = Convert.ToString(rdr["DepartureTime"]);
            vehicleModel.Parked = Convert.ToBoolean(rdr["Parked"]);
            return vehicleModel;
        }

        #endregion
    }
}