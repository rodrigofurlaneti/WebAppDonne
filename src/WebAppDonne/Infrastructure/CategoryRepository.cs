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
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    this.logger.Trace("Donne_GetAllCategorys");
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_GetAll", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        listCategoryModel = GetListCategoryModel(sqlDataReader, listCategoryModel);
                    }
                    return listCategoryModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_Donne_CategoryGetAll assíncrono " + ex.Message;
                    this.logger.TraceException("Donne_GetAllCategorys");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategorysAsync()
        {
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                this.logger.Trace("GetAllCategorysAsync");
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_GetAll", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    listCategoryModel = GetListCategoryModel(sqlDataReader, listCategoryModel);
                }
                return listCategoryModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_Donne_CategoryGetAll assíncrono " + ex.Message;
                this.logger.TraceException("Donne_GetAllCategorysAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_GetById", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        categoryModel = GetCategoryModel(sqlDataReader, categoryModel);
                    }
                }
                logger.Trace("Donne_GetByIdAsync");
                return categoryModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista a categoria, utilizando a procedure USP_Donne_CategoryGetById assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public CategoryModel GetById(int id)
        {
            try
            {
                CategoryModel categoryModel = new CategoryModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_GetById", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        categoryModel = GetCategoryModel(sqlDataReader, categoryModel);
                    }
                }
                logger.Trace("Donne_GetById");
                return categoryModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista a categoria, utilizando a procedure USP_Donne_CategoryGetById síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(CategoryModel categoryModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_Insert", sqlConnection);
            GetSqlCommandBuyerModel(sqlCommand, categoryModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Donne_Insert");
        }

        public async Task InsertAsync(CategoryModel categoryModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_Insert", sqlConnection);
                GetSqlCommandBuyerModel(sqlCommand, categoryModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Donne_InsertAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir uma nova categoria, utilizando a procedure USP_Donne_Category_Insert assíncrono " + ex.Message;
                logger.TraceException("Donne_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int CategoryId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_Delete", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CategoryId", CategoryId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int CategoryId)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_Category_Delete", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CategoryId", CategoryId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("DeleteAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao deletar uma categoria, utilizando a procedure USP_Donne_CategoryDelete assíncrono " + ex.Message;
                logger.TraceException("Donne_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(CategoryModel Category)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_CategoryUpdate", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
            sqlCommand.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", Category.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", Category.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", Category.UserName);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(CategoryModel Category)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_CategoryUpdate", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
                sqlCommand.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
                sqlCommand.Parameters.AddWithValue("@DateInsert", Category.DateInsert);
                sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@UserId", Category.UserId);
                sqlCommand.Parameters.AddWithValue("@UserName", Category.UserName);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma categoria, utilizando a procedure USP_Donne_CategoryUpdate assíncrono " + ex.Message;
                logger.TraceException("Donne_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers
        private List<CategoryModel> GetListCategoryModel(SqlDataReader sqlDataReader, List<CategoryModel> listCategoryModel)
        {
            CategoryModel categoryModel = new CategoryModel();
            categoryModel = GetCategoryModel(sqlDataReader, categoryModel);
            listCategoryModel.Add(categoryModel);
            return listCategoryModel;
        }

        private CategoryModel GetCategoryModel(SqlDataReader sqlDataReader, CategoryModel categoryModel)
        {
            categoryModel.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
            categoryModel.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
            categoryModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            categoryModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            categoryModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            categoryModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            return categoryModel;
        }

        private void GetSqlCommandBuyerModel(SqlCommand sqlCommand, CategoryModel categoryModel)
        {
            sqlCommand.Parameters.AddWithValue("@CategoryId", categoryModel.CategoryId);
            sqlCommand.Parameters.AddWithValue("@CategoryName", categoryModel.CategoryName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", categoryModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", categoryModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", categoryModel.UserName);
        }

        #endregion
    }
}