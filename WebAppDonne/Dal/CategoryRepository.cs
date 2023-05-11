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
                    CategoryModel category = new CategoryModel();
                    category.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    category.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    category.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    category.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    category.UserId = Convert.ToInt32(rdr["UserId"]);
                    category.UserName = Convert.ToString(rdr["UserName"]);
                    listCategoryModel.Add(category);
                }
            }
            return listCategoryModel;
        }

        public CategoryModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            CategoryModel category = new CategoryModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
            return category;
        }

        public void Insert(CategoryModel Category)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
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
            cmd.Parameters.AddWithValue("@DateInsert", Category.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", Category.UserId);
            cmd.Parameters.AddWithValue("@UserName", Category.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}