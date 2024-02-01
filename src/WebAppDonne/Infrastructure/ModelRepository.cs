using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class ModelRepository : BaseRepository
    {
        #region Constructor

        public ModelRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleModel> GetAllVehicleModels()
        {
            try
            {
                List<VehicleModel> listModel = new List<VehicleModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleModelGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                        listModel.Add(vehicleModel);
                    }
                }
                logger.Trace("GetAllVehicleModels");
                return listModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            List<VehicleModel> listModel = new List<VehicleModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleModelGetAll", con))
                try
                {
                    logger.Trace("GetAllVehicleModelsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                        listModel.Add(vehicleModel);
                    }
                    return listModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<VehicleModel> GetByStatus(int status)
        {
            try
            {
                List<VehicleModel> listModel = new List<VehicleModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleModelGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleModel vehicleModel = new VehicleModel();
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                        listModel.Add(vehicleModel);
                    }
                }
                logger.Trace("GetByStatus");
                return listModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleModel>> GetByStatusAsync(int status)
        {
            List<VehicleModel> listModel = new List<VehicleModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleModelGetStatus", con))
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
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                        listModel.Add(vehicleModel);
                    }
                    return listModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetStatus, assíncrono. " + ex.Message;
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
                    SqlCommand cmd = new SqlCommand("USP_VehicleModelGetById", con);
                    cmd.Parameters.AddWithValue("@VehicleModelId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                    }
                }
                logger.Trace("GetById");
                return vehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            VehicleModel vehicleModel = new VehicleModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleModelGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@VehicleModelId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        vehicleModel.VehicleModelId = Convert.ToInt32(rdr["VehicleModelId"]);
                        vehicleModel.VehicleModelName = Convert.ToString(rdr["VehicleModelName"]);
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelInsert", con);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelInsert", con);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int ModelId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelDelete", con);
            cmd.Parameters.AddWithValue("@VehicleModelId", ModelId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int ModelId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelDelete", con);
            cmd.Parameters.AddWithValue("@VehicleModelId", ModelId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleModelUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            cmd.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}