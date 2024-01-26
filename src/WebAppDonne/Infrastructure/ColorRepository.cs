using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class ColorRepository : BaseRepository
    {
        #region Constructor

        public ColorRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<ColorModel> GetAllColors()
        {
            try
            {
                List<ColorModel> listColorModel = new List<ColorModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ColorGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ColorModel ColorModel = new ColorModel();
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                        listColorModel.Add(ColorModel);
                    }
                }
                logger.Trace("GetAllColors");
                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_ColorGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<ColorModel>> GetAllColorsAsync()
        {
            List<ColorModel> listColorModel = new List<ColorModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ColorGetAll", con))
                try
                {
                    logger.Trace("GetAllColorsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ColorModel ColorModel = new ColorModel();
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                        listColorModel.Add(ColorModel);
                    }
                    return listColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ColorGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<ColorModel> GetByStatus(int status)
        {
            try
            {
                List<ColorModel> listColorModel = new List<ColorModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ColorGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ColorModel ColorModel = new ColorModel();
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                        listColorModel.Add(ColorModel);
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

        public async Task<IEnumerable<ColorModel>> GetByStatusAsync(int status)
        {
            List<ColorModel> listColorModel = new List<ColorModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ColorGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ColorModel ColorModel = new ColorModel();
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                        listColorModel.Add(ColorModel);
                    }
                    return listColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ColorGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public ColorModel GetById(int id)
        {
            try
            {
                ColorModel ColorModel = new ColorModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ColorGetById", con);
                    cmd.Parameters.AddWithValue("@ColorId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                    }
                }
                logger.Trace("GetById");
                return ColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_ColorGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<ColorModel> GetByIdAsync(int id)
        {
            ColorModel ColorModel = new ColorModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ColorGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@ColorId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ColorModel.ColorId = Convert.ToInt32(rdr["ColorId"]);
                        ColorModel.ColorName = Convert.ToString(rdr["ColorName"]);
                    }
                    return ColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ColorGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(ColorModel ColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorInsert", con);
            cmd.Parameters.AddWithValue("@ColorName", ColorModel.ColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(ColorModel ColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorInsert", con);
            cmd.Parameters.AddWithValue("@ColorName", ColorModel.ColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int ColorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorDelete", con);
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int ColorId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorDelete", con);
            cmd.Parameters.AddWithValue("@ColorId", ColorId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(ColorModel ColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorUpdate", con);
            cmd.Parameters.AddWithValue("@ColorId", ColorModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", ColorModel.ColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(ColorModel ColorModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ColorUpdate", con);
            cmd.Parameters.AddWithValue("@ColorId", ColorModel.ColorId);
            cmd.Parameters.AddWithValue("@ColorName", ColorModel.ColorName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}