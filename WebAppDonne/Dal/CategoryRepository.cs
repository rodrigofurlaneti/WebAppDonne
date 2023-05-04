using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class CategoryRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CategoryRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CategoryModel> GetAllCategorys()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CategoryModel> listCategoryModel = new List<CategoryModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CategoryGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CategoryModel Category = new CategoryModel();
                    Category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    Category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    Category.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    Category.StoreName = Convert.ToString(rdr["StoreName"]);
                    listCategoryModel.Add(Category);
                }
            }
            return listCategoryModel;
        }

        public CategoryModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            CategoryModel Category = new CategoryModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CategoryGetById", con);
                cmd.Parameters.AddWithValue("@CategoryId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    Category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    Category.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    Category.StoreName = Convert.ToString(rdr["StoreName"]);
                }
            }
            return Category;
        }

        public void Insert(CategoryModel Category)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryInsert", con);
            cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
            cmd.Parameters.AddWithValue("@StoreId", Category.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", Category.StoreName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int CategoryId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryDelete", con);
            cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(CategoryModel Category)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CategoryUpdate", con);
            cmd.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", Category.CategoryName);
            cmd.Parameters.AddWithValue("@StoreId", Category.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", Category.StoreName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
