using Business.Donne;
using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class ProductRepository : BaseRepository
    {
        #region Constructor

        public ProductRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<ProductModel> GetAllProducts()
        {
            commandText = "USP_Donne_Product_GetAll";
            List<ProductModel> listProductModel = new List<ProductModel>();
            using (SqlConnection sqlConnection  = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListProductModel(sqlDataReader, listProductModel);
                }
            }
            logger.Trace("Product_GetAll");
            return listProductModel;
        }


        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            commandText = "USP_Donne_Product_GetAll";
            List<ProductModel> listProductModel = new List<ProductModel>();
            using (SqlConnection sqlConnection  = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListProductModel(sqlDataReader, listProductModel);
                    }
                    logger.Trace("Product_GetAllAsync");
                    return listProductModel;
                }
                catch (Exception ex)
                {
                    string mensagem = "Erro ao consumir a método GetAllPaymentsAsync " + ex.Message;
                    logger.TraceException("Product_GetAllPaymentsAsync");
                    throw new ArgumentNullException(mensagem);
                }                
        }

        public ProductModel GetById(int id)
        {
            commandText = "USP_Donne_Product_GetById";
            ProductModel productModel = new ProductModel();
            using (SqlConnection sqlConnection  = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProductId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetProductModel(sqlDataReader, productModel);
                }
            }
            logger.Trace("GetById");
            return productModel;
        }

        public async Task<ProductModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_Product_GetById";
            ProductModel productModel = new ProductModel();
            using (SqlConnection sqlConnection  = new SqlConnection(connectionString))
            try
            {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ProductId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetProductModel(sqlDataReader, productModel);
                    }
                logger.Trace("GetByIdAsync");
                return productModel;
            }
            catch (Exception ex)
            {
                    string mensagem = "Erro ao consumir a método GetById " + ex.Message;
                    logger.TraceException("GetById");
                    throw new ArgumentNullException(mensagem);
            }
        }

        public void Insert(ProductModel productModel)
        {
            commandText = "USP_Donne_Product_Insert";
            productModel = ProductBusiness.ProductModelValid(productModel);
            SqlConnection sqlConnection  = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandProductModelInsert(sqlCommand, productModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Product_Insert");
        }

        public async Task InsertAsync(ProductModel productModel)
        {
            try
            {
                commandText = "USP_Donne_Product_Insert";
                productModel = ProductBusiness.ProductModelValid(productModel);
                SqlConnection sqlConnection  = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandProductModelInsert(sqlCommand, productModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Product_InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método InsertAsync " + ex.Message;
                logger.TraceException("Product_InsertAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        public void Delete(int ProductId)
        {
            commandText = "USP_Donne_Product_Delete";
            SqlConnection sqlConnection  = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Product_Delete");
        }

        public async Task DeleteAsync(int ProductId)
        {
            try
            {
                commandText = "USP_Donne_Product_Delete";
                SqlConnection sqlConnection  = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@ProductId", ProductId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Product_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método DeleteAsync " + ex.Message;
                logger.TraceException("Product_DeleteAsync");
                throw new ArgumentNullException(mensagem);
            }
        }

        public void Update(ProductModel productModel)
        {
            commandText = "USP_Donne_Product_Update";
            SqlConnection sqlConnection  = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandProductModelUpdate(sqlCommand, productModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Product_Update");
        }

        public async Task UpdateAsync(ProductModel productModel)
        {
            try
            {
                commandText = "USP_Donne_Product_Update";
                SqlConnection sqlConnection  = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandProductModelUpdate(sqlCommand, productModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Product_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagem = "Erro ao consumir a método UpdateAsync " + ex.Message;
                logger.TraceException("Product_UpdateAsync");
                throw new ArgumentNullException(mensagem);
            }

        }

        #endregion

        #region Helpers
        private List<ProductModel> GetListProductModel(SqlDataReader sqlDataReader, List<ProductModel> listProductModel)
        {
            ProductModel productModel = new ProductModel();
            productModel = GetProductModel(sqlDataReader, productModel);
            listProductModel.Add(productModel);
            return listProductModel;
        }

        private ProductModel GetProductModel(SqlDataReader sqlDataReader, ProductModel productModel)
        {
            productModel.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
            productModel.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
            productModel.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
            productModel.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
            productModel.CostPrice = Convert.ToString(sqlDataReader["CostPrice"]);
            productModel.SalePrice = Convert.ToString(sqlDataReader["SalePrice"]);
            productModel.QuantityStock = Convert.ToInt32(sqlDataReader["QuantityStock"]);
            productModel.MinimumStockQuantity = Convert.ToInt32(sqlDataReader["MinimumStockQuantity"]);
            productModel.TotalValueCostOfInventory = Convert.ToString(sqlDataReader["TotalValueCostOfInventory"]);
            productModel.TotalValueSaleStock = Convert.ToString(sqlDataReader["TotalValueSaleStock"]);
            productModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            productModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            productModel.NeedToPrint = Convert.ToInt32(sqlDataReader["NeedToPrint"]);
            productModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            productModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            productModel.Status = Convert.ToInt32(sqlDataReader["Status"]);
            productModel.QuantityToBuy = Convert.ToInt32(sqlDataReader["QuantityToBuy"]);
            productModel.TotalValueOfLastPurchase = Convert.ToString(sqlDataReader["TotalValueOfLastPurchase"]);
            return productModel;
        }

        private void GetSqlCommandProductModelInsert(SqlCommand sqlCommand, ProductModel productModel)
        {
            sqlCommand.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            sqlCommand.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
            sqlCommand.Parameters.AddWithValue("@CategoryName", productModel.CategoryName);
            sqlCommand.Parameters.AddWithValue("@CostPrice", productModel.CostPrice);
            sqlCommand.Parameters.AddWithValue("@SalePrice", productModel.SalePrice);
            sqlCommand.Parameters.AddWithValue("@QuantityStock", productModel.QuantityStock);
            sqlCommand.Parameters.AddWithValue("@MinimumStockQuantity", productModel.MinimumStockQuantity);
            sqlCommand.Parameters.AddWithValue("@TotalValueCostOfInventory", productModel.TotalValueCostOfInventory);
            sqlCommand.Parameters.AddWithValue("@TotalValueSaleStock", productModel.TotalValueSaleStock);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", productModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@NeedToPrint", productModel.NeedToPrint);
            sqlCommand.Parameters.AddWithValue("@UserId", productModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", productModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", productModel.Status);
            sqlCommand.Parameters.AddWithValue("@QuantityToBuy", productModel.QuantityToBuy);
            sqlCommand.Parameters.AddWithValue("@TotalValueOfLastPurchase", productModel.TotalValueOfLastPurchase);
        }

        private void GetSqlCommandProductModelUpdate(SqlCommand sqlCommand, ProductModel productModel)
        {
            sqlCommand.Parameters.AddWithValue("@ProductId", productModel.ProductId);
            sqlCommand.Parameters.AddWithValue("@ProductName", productModel.ProductName);
            sqlCommand.Parameters.AddWithValue("@CategoryId", productModel.CategoryId);
            sqlCommand.Parameters.AddWithValue("@CategoryName", productModel.CategoryName);
            sqlCommand.Parameters.AddWithValue("@CostPrice", productModel.CostPrice);
            sqlCommand.Parameters.AddWithValue("@SalePrice", productModel.SalePrice);
            sqlCommand.Parameters.AddWithValue("@QuantityStock", productModel.QuantityStock);
            sqlCommand.Parameters.AddWithValue("@MinimumStockQuantity", productModel.MinimumStockQuantity);
            sqlCommand.Parameters.AddWithValue("@TotalValueCostOfInventory", productModel.TotalValueCostOfInventory);
            sqlCommand.Parameters.AddWithValue("@TotalValueSaleStock", productModel.TotalValueSaleStock);
            sqlCommand.Parameters.AddWithValue("@DateInsert", productModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@NeedToPrint", productModel.NeedToPrint);
            sqlCommand.Parameters.AddWithValue("@UserId", productModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", productModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", productModel.Status);
            sqlCommand.Parameters.AddWithValue("@QuantityToBuy", productModel.QuantityToBuy);
            sqlCommand.Parameters.AddWithValue("@TotalValueOfLastPurchase", productModel.TotalValueOfLastPurchase);
        }
        #endregion
    }
}
