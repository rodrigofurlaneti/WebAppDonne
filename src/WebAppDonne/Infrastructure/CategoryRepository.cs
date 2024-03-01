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
            commandText = "USP_Donne_Category_GetAll";
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListCategoryModel(sqlDataReader, listCategoryModel);
                    }
                    this.logger.Trace("Category_GetAll");
                    return listCategoryModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_Donne_Category_GetAll assíncrono " + ex.Message;
                    this.logger.TraceException("Category_GetAll");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategorysAsync()
        {
            commandText = "USP_Donne_Category_GetAll";
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    GetListCategoryModel(sqlDataReader, listCategoryModel);
                }
                this.logger.Trace("Category_GetAllAsync");
                return listCategoryModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista as categorias, utilizando a procedure USP_Donne_CategoryGetAll assíncrono " + ex.Message;
                this.logger.TraceException("Category_GetAllAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            try
            {
                commandText = "USP_Donne_Category_GetById";
                CategoryModel categoryModel = new CategoryModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetCategoryModel(sqlDataReader, categoryModel);
                    }
                }
                logger.Trace("Category_GetByIdAsync");
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
                commandText = "USP_Donne_Category_GetById";
                CategoryModel categoryModel = new CategoryModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CategoryId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetCategoryModel(sqlDataReader, categoryModel);
                    }
                }
                logger.Trace("Category_GetById");
                return categoryModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista a categoria, utilizando a procedure USP_Donne_Category_GetById síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(CategoryModel categoryModel)
        {
            commandText = "USP_Donne_Category_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelInsert(sqlCommand, categoryModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Category_Insert");
        }

        public async Task InsertAsync(CategoryModel categoryModel)
        {
            try
            {
                commandText = "USP_Donne_Category_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandBuyerModelInsert(sqlCommand, categoryModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Category_InsertAsync");
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
            commandText = "USP_Donne_Category_Delete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
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
                commandText = "USP_Donne_Category_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CategoryId", CategoryId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Category_DeleteAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao deletar uma categoria, utilizando a procedure USP_Donne_Category_Delete assíncrono " + ex.Message;
                logger.TraceException("Category_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Update(CategoryModel categoryModel)
        {
            commandText = "USP_Donne_Category_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelUpdate(sqlCommand, categoryModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Category_Update");
        }

        public async Task UpdateAsync(CategoryModel categoryModel)
        {
            try
            {
                commandText = "USP_Donne_Category_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandBuyerModelUpdate(sqlCommand, categoryModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                logger.Trace("Category_UpdateAsync");
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma categoria, utilizando a procedure USP_Donne_Category_Update assíncrono " + ex.Message;
                logger.TraceException("Category_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers
        private static void GetListCategoryModel(SqlDataReader sqlDataReader, List<CategoryModel> listCategoryModel)
        {
            CategoryModel categoryModel = new CategoryModel();
            GetCategoryModel(sqlDataReader, categoryModel);
            listCategoryModel.Add(categoryModel);
        }

        private static void GetCategoryModel(SqlDataReader sqlDataReader, CategoryModel categoryModel)
        {
            categoryModel.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
            categoryModel.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
            categoryModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            categoryModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            categoryModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            categoryModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
        }

        private static void GetSqlCommandBuyerModelInsert(SqlCommand sqlCommand, CategoryModel categoryModel)
        {
            sqlCommand.Parameters.AddWithValue("@CategoryName", categoryModel.CategoryName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", categoryModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", categoryModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", categoryModel.UserName);
        }

        private static void GetSqlCommandBuyerModelUpdate(SqlCommand sqlCommand, CategoryModel categoryModel)
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