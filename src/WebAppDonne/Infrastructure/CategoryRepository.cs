using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class CategoryRepository : BaseRepository
    {
        #region Constructor

        public CategoryRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<CategoryModel> GetAllCategorys()
        {
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoryGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CategoryModel category = new CategoryModel();
                        category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                        category.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        category.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        category.UserId = Convert.ToInt32(rdr["UserId"]);
                        category.UserName = Convert.ToString(rdr["UserName"]);
                        listCategoryModel.Add(category);
                    }
                    logger.Trace("GetAllCategorys");
                    return listCategoryModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_CategoryGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategorysAsync()
        {
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                SqlCommand cmd = new SqlCommand("USP_CategoryGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    CategoryModel category = new CategoryModel();
                    category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    category.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    category.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    category.UserId = Convert.ToInt32(rdr["UserId"]);
                    category.UserName = Convert.ToString(rdr["UserName"]);
                    listCategoryModel.Add(category);
                }
                logger.Trace("GetAllCategorysAsync");
                return listCategoryModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_CategoryGetAll assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            try
            {
                CategoryModel category = new CategoryModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoryGetById", con);
                    cmd.Parameters.AddWithValue("@CategoryId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                        category.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        category.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        category.UserId = Convert.ToInt32(rdr["UserId"]);
                        category.UserName = Convert.ToString(rdr["UserName"]);
                    }
                }
                logger.Trace("GetByIdAsync");
                return category;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a categoria, utilizando a procedure USP_CategoryGetById assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public CategoryModel GetById(int id)
        {
            try
            {
                CategoryModel category = new CategoryModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_CategoryGetById", con);
                    cmd.Parameters.AddWithValue("@CategoryId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                        category.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        category.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        category.UserId = Convert.ToInt32(rdr["UserId"]);
                        category.UserName = Convert.ToString(rdr["UserName"]);
                    }
                }
                logger.Trace("GetById");
                return category;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a categoria, utilizando a procedure USP_CategoryGetById síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(CategoryModel Category)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryInsert", con);
            cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", Category.UserId);
            cmd.Parameters.AddWithValue("@UserName", Category.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(CategoryModel Category)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_CategoryInsert", con);
                cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", Category.UserId);
                cmd.Parameters.AddWithValue("@UserName", Category.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                logger.Trace("InsertAsync");
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir uma nova categoria, utilizando a procedure USP_CategoryInsert assíncrono " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int CategoryId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryDelete", con);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int CategoryId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_CategoryDelete", con);
                cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                logger.Trace("DeleteAsync");
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao deletar uma categoria, utilizando a procedure USP_CategoryDelete assíncrono " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(CategoryModel Category)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryUpdate", con);
            cmd.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
            cmd.Parameters.AddWithValue("@DateInsert", Category.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", Category.UserId);
            cmd.Parameters.AddWithValue("@UserName", Category.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(CategoryModel Category)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_CategoryUpdate", con);
                cmd.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                cmd.Parameters.AddWithValue("@DateInsert", Category.DateInsert);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", Category.UserId);
                cmd.Parameters.AddWithValue("@UserName", Category.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                logger.Trace("UpdateAsync");
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma categoria, utilizando a procedure USP_CategoryUpdate assíncrono " + ex.Message;
                logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion
    }
}