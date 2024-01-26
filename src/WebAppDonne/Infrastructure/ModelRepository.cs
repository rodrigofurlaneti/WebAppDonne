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

        public IEnumerable<Model> GetAllModels()
        {
            try
            {
                List<Model> listModel = new List<Model>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ModelGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Model Model = new Model();
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                        listModel.Add(Model);
                    }
                }
                logger.Trace("GetAllModels");
                return listModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_ModelGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<Model>> GetAllModelsAsync()
        {
            List<Model> listModel = new List<Model>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ModelGetAll", con))
                try
                {
                    logger.Trace("GetAllModelsAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Model Model = new Model();
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                        listModel.Add(Model);
                    }
                    return listModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ModelGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public IEnumerable<Model> GetByStatus(int status)
        {
            try
            {
                List<Model> listModel = new List<Model>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ModelGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Model Model = new Model();
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                        listModel.Add(Model);
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

        public async Task<IEnumerable<Model>> GetByStatusAsync(int status)
        {
            List<Model> listModel = new List<Model>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ModelGetStatus", con))
                try
                {
                    logger.Trace("GetByStatusAsync");
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Model Model = new Model();
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                        listModel.Add(Model);
                    }
                    return listModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ModelGetStatus, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public Model GetById(int id)
        {
            try
            {
                Model Model = new Model();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ModelGetById", con);
                    cmd.Parameters.AddWithValue("@ModelId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                    }
                }
                logger.Trace("GetById");
                return Model;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_ModelGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<Model> GetByIdAsync(int id)
        {
            Model Model = new Model();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ModelGetById", con))
                try
                {
                    logger.Trace("GetByIdAsync");
                    cmd.Parameters.AddWithValue("@ModelId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        Model.ModelId = Convert.ToInt32(rdr["ModelId"]);
                        Model.ModelName = Convert.ToString(rdr["ModelName"]);
                    }
                    return Model;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ModelGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(Model Model)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelInsert", con);
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(Model Model)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelInsert", con);
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int ModelId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelDelete", con);
            cmd.Parameters.AddWithValue("@ModelId", ModelId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int ModelId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelDelete", con);
            cmd.Parameters.AddWithValue("@ModelId", ModelId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(Model Model)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelUpdate", con);
            cmd.Parameters.AddWithValue("@ModelId", Model.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(Model Model)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_ModelUpdate", con);
            cmd.Parameters.AddWithValue("@ModelId", Model.ModelId);
            cmd.Parameters.AddWithValue("@ModelName", Model.ModelName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}