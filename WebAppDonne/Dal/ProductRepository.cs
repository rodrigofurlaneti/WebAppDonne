using WebAppDonne.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebAppDonne.Dal
{
    public class ProductRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public ProductRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<ProductModel> GetAllProducts()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<ProductModel> listProductModel = new List<ProductModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_ProductGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductModel product = new ProductModel();
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.ProductName = Convert.ToString(rdr["ProductName"]);
                    product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    product.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    product.CostPrice = Convert.ToString(rdr["CostPrice"]);
                    product.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    product.QuantityStock = Convert.ToInt32(rdr["QuantityStock"]);
                    product.MinimumStockQuantity = Convert.ToInt32(rdr["MinimumStockQuantity"]);
                    product.TotalValueCostOfInventory = Convert.ToString(rdr["TotalValueCostOfInventory"]);
                    product.TotalValueSaleStock = Convert.ToString(rdr["TotalValueSaleStock"]);
                    product.ImagePath = Convert.ToString(rdr["ImagePath"]);
                    product.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    product.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    product.NeedToPrint = Convert.ToBoolean(rdr["NeedToPrint"]);
                    product.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    product.StoreName = Convert.ToString(rdr["StoreName"]);
                    product.UserId = Convert.ToInt32(rdr["UserId"]);
                    product.UserName = Convert.ToString(rdr["UserName"]);
                    product.Status = Convert.ToBoolean(rdr["Status"]);
                    listProductModel.Add(product);
                }
            }
            return listProductModel;
        }

        public ProductModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            ProductModel product = new ProductModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_GetAllGetById", con);
                cmd.Parameters.AddWithValue("@ProductId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.ProductName = Convert.ToString(rdr["ProductName"]);
                    product.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                    product.CategoryName = Convert.ToString(rdr["CategoryName"]);
                    product.CostPrice = Convert.ToString(rdr["CostPrice"]);
                    product.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    product.QuantityStock = Convert.ToInt32(rdr["QuantityStock"]);
                    product.MinimumStockQuantity = Convert.ToInt32(rdr["MinimumStockQuantity"]);
                    product.TotalValueCostOfInventory = Convert.ToString(rdr["TotalValueCostOfInventory"]);
                    product.TotalValueSaleStock = Convert.ToString(rdr["TotalValueSaleStock"]);
                    product.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    product.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    product.ImagePath = Convert.ToString(rdr["ImagePath"]);
                    product.NeedToPrint = Convert.ToBoolean(rdr["NeedToPrint"]);
                    product.StoreId = Convert.ToInt32(rdr["StoreId"]);
                    product.StoreName = Convert.ToString(rdr["StoreName"]);
                    product.UserId = Convert.ToInt32(rdr["UserId"]);
                    product.UserName = Convert.ToString(rdr["UserName"]);
                    product.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            return product;
        }

        public void Insert(ProductModel product)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProductInsert", con);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
            cmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
            cmd.Parameters.AddWithValue("@QuantityStock", product.QuantityStock);
            cmd.Parameters.AddWithValue("@MinimumStockQuantity", product.MinimumStockQuantity);
            cmd.Parameters.AddWithValue("@TotalValueCostOfInventory", product.TotalValueCostOfInventory);
            cmd.Parameters.AddWithValue("@TotalValueSaleStock", product.TotalValueSaleStock);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
            cmd.Parameters.AddWithValue("@NeedToPrint", product.NeedToPrint);
            cmd.Parameters.AddWithValue("@StoreId", product.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", product.StoreName); 
            cmd.Parameters.AddWithValue("@UserId", product.UserId);
            cmd.Parameters.AddWithValue("@UserName", product.UserName);
            cmd.Parameters.AddWithValue("@Status", product.Status);

            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int ProductId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProductDelete", con);
            cmd.Parameters.AddWithValue("@ProductId", ProductId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(ProductModel product)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_ProductUpdate", con);
            cmd.Parameters.AddWithValue("@ProductId", product.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
            cmd.Parameters.AddWithValue("@CategoryId", product.CategoryId);
            cmd.Parameters.AddWithValue("@CategoryName", product.CategoryName);
            cmd.Parameters.AddWithValue("@CostPrice", product.CostPrice);
            cmd.Parameters.AddWithValue("@SalePrice", product.SalePrice);
            cmd.Parameters.AddWithValue("@QuantityStock", product.QuantityStock);
            cmd.Parameters.AddWithValue("@MinimumStockQuantity", product.MinimumStockQuantity);
            cmd.Parameters.AddWithValue("@TotalValueCostOfInventory", product.TotalValueCostOfInventory);
            cmd.Parameters.AddWithValue("@TotalValueSaleStock", product.TotalValueSaleStock);
            cmd.Parameters.AddWithValue("@DateInsert", product.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@NeedToPrint", product.NeedToPrint);
            cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
            cmd.Parameters.AddWithValue("@StoreId", product.StoreId);
            cmd.Parameters.AddWithValue("@StoreName", product.StoreName);
            cmd.Parameters.AddWithValue("@UserId", product.UserId);
            cmd.Parameters.AddWithValue("@UserName", product.UserName);
            cmd.Parameters.AddWithValue("@Status", product.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
