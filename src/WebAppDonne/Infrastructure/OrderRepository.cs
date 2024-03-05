using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class OrderRepository : BaseRepository
    {
        #region Constructor

        public OrderRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<OrderModel> GetAllOrders()
        {
            try
            {
                commandText = "USP_Donne_Order_GetAll";
                List<OrderModel> listOrderModel = new List<OrderModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListOrderModel(sqlDataReader, listOrderModel);
                    }
                }
                logger.Trace("Order_GetAll");
                return listOrderModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetAll síncrono " + ex.Message;
                this.logger.TraceException("Order_GetAll");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            try
            {
                commandText = "USP_Donne_Order_GetAll";
                List<OrderModel> listOrderModel = new List<OrderModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListOrderModel(sqlDataReader, listOrderModel);
                    }
                    this.logger.Trace("Order_GetAllAsync");
                }

                return listOrderModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_GetAllAsync");
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetAll assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public OrderModel GetById(int id)
        {
            try
            {
                commandText = "USP_Donne_Order_GetById";
                OrderModel orderModel = new OrderModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@OrderId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetOrderModel(sqlDataReader, orderModel);
                    }
                }
                logger.Trace("Order_GetById");
                return orderModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_GetById");
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetById síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            try
            {
                commandText = "USP_Donne_Order_GetById";
                OrderModel orderModel = new OrderModel();
                logger.Trace("Order_GetByIdAsync");
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@OrderId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetOrderModel(sqlDataReader, orderModel);
                    }
                }

                return orderModel;
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_GetByIdAsync");
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetById assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(OrderModel orderModel)
        {
            try
            {
                commandText = "USP_Donne_Order_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandOrderModelInsert(sqlCommand, orderModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("Order_Insert");
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_Insert");
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_Insert síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task InsertAsync(OrderModel orderModel)
        {
            try
            {
                this.logger.Trace("Order_InsertAsync");
                commandText = "USP_Donne_Order_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandOrderModelInsert(sqlCommand, orderModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                await UpdateProduct(orderModel);

            }
            catch (Exception ex)
            {
                this.logger.TraceException("Order_InsertAsync");
                string mensagemErro = "Erro ao inserir um novo pedido, utilizando a procedure USP_Donne_Order_Insert assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }


        public void Delete(int OrderId)
        {
            try
            {
                this.logger.Trace("Order_Delete");
                commandText = "USP_Donne_Order_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", OrderId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_Delete");
                string mensagemErro = "Erro ao inserir um novo pedido, utilizando a procedure USP_Donne_Delete síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task DeleteAsync(int OrderId)
        {
            try
            {
                this.logger.Trace("Order_DeleteAsync");
                commandText = "USP_Donne_Order_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@OrderId", OrderId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir o pedido, utilizando a procedure USP_Donne_Order_Delete assíncrono " + ex.Message;
                this.logger.TraceException("Order_DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(OrderModel orderModel)
        {
            try
            {
                commandText = "USP_Donne_Order_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandOrderModelUpdate(sqlCommand, orderModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                logger.Trace("Order_Update");
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao excluir o pedido, utilizando a procedure USP_Donne_Order_Update síncrono " + ex.Message;
                this.logger.TraceException("Order_Update");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task UpdateAsync(OrderModel orderModel)
        {
            try
            {
                this.logger.Trace("Order_UpdateAsync");
                commandText = "USP_Donne_Order_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandOrderModelUpdate(sqlCommand, orderModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
            }
            catch (ArgumentNullException ex)
            {
                this.logger.TraceException("Order_UpdateAsync");
                string mensagemErro = "Erro ao atualizar o pedido, utilizando a procedure USP_Donne_Order_Update assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers
        private static void GetListOrderModel(SqlDataReader sqlDataReader, List<OrderModel> listOrderModel)
        {
            OrderModel orderModel = new OrderModel();
            GetOrderModel(sqlDataReader, orderModel);
            listOrderModel.Add(orderModel);
        }

        private static void GetOrderModel(SqlDataReader sqlDataReader, OrderModel orderModel)
        {
            orderModel.OrderId = Convert.ToInt32(sqlDataReader["OrderId"]);
            orderModel.CommandId = Convert.ToInt32(sqlDataReader["CommandId"]);
            orderModel.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
            orderModel.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
            orderModel.BuyerName = Convert.ToString(sqlDataReader["BuyerName"]);
            orderModel.SalePrice = Convert.ToString(sqlDataReader["SalePrice"]);
            orderModel.Amount = Convert.ToInt32(sqlDataReader["Amount"]);
            orderModel.TotalSalePrice = Convert.ToString(sqlDataReader["TotalSalePrice"]);
            orderModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            orderModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            orderModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            orderModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
        }

        private static void GetSqlCommandOrderModelInsert(SqlCommand sqlCommand, OrderModel orderModel)
        {
            sqlCommand.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
            sqlCommand.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
            sqlCommand.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
            sqlCommand.Parameters.AddWithValue("@BuyerName", orderModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
            sqlCommand.Parameters.AddWithValue("@Amount", orderModel.Amount);
            sqlCommand.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", orderModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", orderModel.UserName);
        }

        private static void GetSqlCommandOrderModelUpdate(SqlCommand sqlCommand, OrderModel orderModel)
        {
            sqlCommand.Parameters.AddWithValue("@OrderId", orderModel.OrderId);
            sqlCommand.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
            sqlCommand.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
            sqlCommand.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
            sqlCommand.Parameters.AddWithValue("@BuyerName", orderModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
            sqlCommand.Parameters.AddWithValue("@Amount", orderModel.Amount);
            sqlCommand.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
            sqlCommand.Parameters.AddWithValue("@DateInsert", orderModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", orderModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", orderModel.UserName);
        }

        private async Task UpdateProduct(OrderModel orderModel)
        {
            ProductRepository productRepository = new ProductRepository(logger);
            var productModel = await productRepository.GetByIdAsync(orderModel.ProductId);
            productModel.QuantityStock = productModel.QuantityStock - orderModel.Amount;
            productModel.DateUpdate = DateTime.Now;
            var totalValueCostOfInventory = Convert.ToDecimal(productModel.CostPrice) * productModel.QuantityStock;
            var totalValueCost = String.Format("{0:0.##}", totalValueCostOfInventory.ToString());
            productModel.TotalValueCostOfInventory = totalValueCost.ToString();
            var totalValueSaleStock = Convert.ToDecimal(productModel.SalePrice) * productModel.QuantityStock;
            var totalValueSale = String.Format("{0:0.##}", totalValueSaleStock.ToString());
            productModel.TotalValueSaleStock = totalValueSale.ToString();
            if (productModel.QuantityStock < productModel.MinimumStockQuantity)
            {
                productModel.QuantityToBuy = productModel.MinimumStockQuantity - productModel.QuantityStock;
                var totalValueOfLastPurchase = productModel.QuantityToBuy * Convert.ToDecimal(productModel.CostPrice);
                productModel.TotalValueOfLastPurchase = totalValueOfLastPurchase.ToString();
            }
            this.logger.Trace("Order_InsertAsync");
            await productRepository.UpdateAsync(productModel);
        }

        #endregion
    }
}
