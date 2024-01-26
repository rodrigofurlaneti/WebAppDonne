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

        public IEnumerable<BrandModel> GetAllBrands()
        {
            try
            {
                List<BrandModel> listBrandModel = new List<BrandModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BrandGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BrandModel BrandModel = new BrandModel();
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                        listBrandModel.Add(BrandModel);
                    }
                }
                logger.Trace("GetAllBrands");
                return listBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BrandGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<BrandModel>> GetAllBrandsAsync()
        {
            List<BrandModel> listBrandModel = new List<BrandModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BrandGetAll", con))
                try
                {
                    logger.Trace("GetAllBrandsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        BrandModel BrandModel = new BrandModel();
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                        listBrandModel.Add(BrandModel);
                    }
                    return listBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_BrandGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<BrandModel> GetByStatus(int status)
        {
            try
            {
                List<BrandModel> listBrandModel = new List<BrandModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BrandGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BrandModel BrandModel = new BrandModel();
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                        listBrandModel.Add(BrandModel);
                    }
                }
                logger.Trace("GetByStatus");
                return listBrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<BrandModel>> GetByStatusAsync(int status)
        {
            List<BrandModel> listBrandModel = new List<BrandModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BrandGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        BrandModel BrandModel = new BrandModel();
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                        listBrandModel.Add(BrandModel);
                    }
                    return listBrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_BrandGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public BrandModel GetById(int id)
        {
            try
            {
                BrandModel BrandModel = new BrandModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BrandGetById", con);
                    cmd.Parameters.AddWithValue("@BrandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                    }
                }
                logger.Trace("GetById");
                return BrandModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BrandGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<BrandModel> GetByIdAsync(int id)
        {
            BrandModel BrandModel = new BrandModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BrandGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@BrandId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        BrandModel.BrandId = Convert.ToInt32(rdr["BrandId"]);
                        BrandModel.BrandName = Convert.ToString(rdr["BrandName"]);
                    }
                    return BrandModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_BrandGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(BrandModel BrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandInsert", con);
            cmd.Parameters.AddWithValue("@BrandName", BrandModel.BrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(BrandModel BrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandInsert", con);
            cmd.Parameters.AddWithValue("@BrandName", BrandModel.BrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int BrandId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandDelete", con);
            cmd.Parameters.AddWithValue("@BrandId", BrandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int BrandId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandDelete", con);
            cmd.Parameters.AddWithValue("@BrandId", BrandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(BrandModel BrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandUpdate", con);
            cmd.Parameters.AddWithValue("@BrandId", BrandModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", BrandModel.BrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(BrandModel BrandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BrandUpdate", con);
            cmd.Parameters.AddWithValue("@BrandId", BrandModel.BrandId);
            cmd.Parameters.AddWithValue("@BrandName", BrandModel.BrandName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}