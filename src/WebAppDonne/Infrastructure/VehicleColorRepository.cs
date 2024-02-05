using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleColorRepository : BaseRepository
    {
        #region Constructor

        public VehicleColorRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleColorModel> GetAllVehicleColors()
        {
            try
            {
                List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleColorGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleColorModel vehicleColorModel = new VehicleColorModel();
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                        listColorModel.Add(vehicleColorModel);
                    }
                }
                logger.Trace("GetAllVehicleColors");
                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleColorModel>> GetAllVehicleColorsAsync()
        {
            List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleColorGetAll", con))
                try
                {
                    logger.Trace("GetAllVehicleColorsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleColorModel vehicleColorModel = new VehicleColorModel();
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                        listColorModel.Add(vehicleColorModel);
                    }
                    return listColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<VehicleColorModel> GetByStatus(int status)
        {
            try
            {
                List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ColorGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleColorModel vehicleColorModel = new VehicleColorModel();
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                        listColorModel.Add(vehicleColorModel);
                    }
                }
                logger.Trace("GetByStatus");
                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleColorModel>> GetByStatusAsync(int status)
        {
            List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleColorGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleColorModel vehicleColorModel = new VehicleColorModel();
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                        listColorModel.Add(vehicleColorModel);
                    }
                    return listColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ColorGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleColorModel GetById(int id)
        {
            try
            {
                VehicleColorModel vehicleColorModel = new VehicleColorModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleColorGetById", con);
                    cmd.Parameters.AddWithValue("@VehicleColorId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                    }
                }
                logger.Trace("GetById");
                return vehicleColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleColorModel> GetByIdAsync(int id)
        {
            VehicleColorModel vehicleColorModel = new VehicleColorModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleColorGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@VehicleColorId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        vehicleColorModel.VehicleColorId = Convert.ToInt32(rdr["VehicleColorId"]);
                        vehicleColorModel.VehicleColorName = Convert.ToString(rdr["VehicleColorName"]);
                    }
                    return vehicleColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleColorModel vehicleColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorInsert", con);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleColorModel vehicleColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorInsert", con);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int ColorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorDelete", con);
            cmd.Parameters.AddWithValue("@VehicleColorId", ColorId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int ColorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorDelete", con);
            cmd.Parameters.AddWithValue("@VehicleColorId", ColorId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(VehicleColorModel vehicleColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleColorModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(VehicleColorModel vehicleColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleColorUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleColorId", vehicleColorModel.VehicleColorId);
            cmd.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}