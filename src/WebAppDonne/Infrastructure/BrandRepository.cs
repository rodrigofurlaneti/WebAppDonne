using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class BrandRepository : BaseRepository
    {
        #region Constructor

        public BrandRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleBrandModel> GetAllVehicleBrands()
        {
            try
            {
                List<VehicleBrandModel> listBrandModel = new List<VehicleBrandModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleBrandGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
                        vehicleBrandModel.VehicleBrandId = Convert.ToInt32(rdr["VehicleBrandId"]);
                        vehicleBrandModel.VehicleBrandName = Convert.ToString(rdr["VehicleBrandName"]);
                        listBrandModel.Add(vehicleBrandModel);
                    }
                }
                logger.Trace("VehicleBrandGetAll");
                return listBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandsAsync()
        {
            List<VehicleBrandModel> listBrandModel = new List<VehicleBrandModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleBrandGetAll", con))
                try
                {
                    logger.Trace("GetAllBrandsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
                        vehicleBrandModel.VehicleBrandId = Convert.ToInt32(rdr["VehicleBrandId"]);
                        vehicleBrandModel.VehicleBrandName = Convert.ToString(rdr["VehicleBrandName"]);
                        listBrandModel.Add(vehicleBrandModel);
                    }
                    return listBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }
        
        public VehicleBrandModel GetById(int id)
        {
            try
            {
                VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_VehicleBrandGetById", con);
                    cmd.Parameters.AddWithValue("@VehicleBrandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        vehicleBrandModel.VehicleBrandId = Convert.ToInt32(rdr["VehicleBrandId"]);
                        vehicleBrandModel.VehicleBrandName = Convert.ToString(rdr["VehicleBrandName"]);
                    }
                }
                logger.Trace("VehicleBrand_GetById");
                return vehicleBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrand_GetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleBrandModel> GetByIdAsync(int id)
        {
            VehicleBrandModel vehicleBrandModel = new VehicleBrandModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_VehicleBrandGetById", con))
                try
                {
                    logger.Trace("VehicleBrand_GetByIdAsync");
                    cmd.Parameters.AddWithValue("@VehicleBrandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        vehicleBrandModel.VehicleBrandId = Convert.ToInt32(rdr["VehicleBrandId"]);
                        vehicleBrandModel.VehicleBrandName = Convert.ToString(rdr["VehicleBrandName"]);
                    }
                    return vehicleBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleBrandGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleBrandModel vehicleBrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandInsert", con);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleBrandModel vehicleBrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandInsert", con);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int BrandId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandDelete", con);
            cmd.Parameters.AddWithValue("@VehicleBrandId", BrandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("VehicleBrand_Delete");
        }

        public async Task DeleteAsync(int BrandId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandDelete", con);
            cmd.Parameters.AddWithValue("@VehicleBrandId", BrandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(VehicleBrandModel vehicleBrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleBrandModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("VehicleVehicle_Update");
        }

        public async Task UpdateAsync(VehicleBrandModel vehicleBrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_VehicleBrandUpdate", con);
            cmd.Parameters.AddWithValue("@VehicleBrandId", vehicleBrandModel.VehicleBrandId);
            cmd.Parameters.AddWithValue("@VehicleBrandName", vehicleBrandModel.VehicleBrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("VehicleBrand_UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}