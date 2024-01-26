using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleTypeRepository : BaseRepository
    {
        #region Constructor

        public VehicleTypeRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleTypeModel> GetAllVehicleTypes()
        {
            try
            {
                List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                        listVehicleTypeModel.Add(vehicleTypeModel);
                    }
                }
                logger.Trace("GetAllVehicleTypes");
                return listVehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleTypeModel>> GetAllVehicleTypesAsync()
        {
            List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetAll", con))
                try
                {
                    logger.Trace("GetAllVehicleTypesAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                        listVehicleTypeModel.Add(vehicleTypeModel);
                    }
                    return listVehicleTypeModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<VehicleTypeModel> GetByStatus(int status)
        {
            try
            {
                List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                        listVehicleTypeModel.Add(vehicleTypeModel);
                    }
                }
                logger.Trace("GetByStatus");
                return listVehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleTypeModel>> GetByStatusAsync(int status)
        {
            List<VehicleTypeModel> listVehicleTypeModel = new List<VehicleTypeModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                        listVehicleTypeModel.Add(vehicleTypeModel);
                    }
                    return listVehicleTypeModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleTypeModel GetById(int id)
        {
            try
            {
                VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetById", con);
                    cmd.Parameters.AddWithValue("@VehicleTypeId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                    }
                }
                logger.Trace("GetById");
                return vehicleTypeModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<VehicleTypeModel> GetByIdAsync(int id)
        {
            VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleTypeGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@VehicleTypeId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        vehicleTypeModel.VehicleTypeId = Convert.ToInt32(rdr["VehicleTypeId"]);
                        vehicleTypeModel.VehicleTypeName = Convert.ToString(rdr["VehicleTypeName"]);
                    }
                    return vehicleTypeModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleTypeGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleTypeModel vehicleTypeModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleTypeModel vehicleTypeModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeInsert", con);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int VehicleTypeId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeDelete", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", VehicleTypeId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int vehicleTypeId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeDelete", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(VehicleTypeModel vehicleTypeModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(VehicleTypeModel vehicleTypeModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleTypeUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleTypeId", vehicleTypeModel.VehicleTypeId);
            cmd.Parameters.AddWithValue("@VehicleTypeName", vehicleTypeModel.VehicleTypeName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}