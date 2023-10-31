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
            List<OrderModel> listOrderModel = new List<OrderModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_OrderGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    OrderModel orderModel = new OrderModel();
                    orderModel.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    orderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    orderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    orderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                    orderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    orderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                    orderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                    orderModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    orderModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    orderModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    orderModel.UserName = Convert.ToString(rdr["UserName"]);
                    listOrderModel.Add(orderModel);
                }
            }
            logger.Trace("GetAllOrders");
            return listOrderModel;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            List<OrderModel> listOrderModel = new List<OrderModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                logger.Trace("GetAllOrdersAsync");
                SqlCommand cmd = new SqlCommand("USP_OrderGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    OrderModel orderModel = new OrderModel();
                    orderModel.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    orderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    orderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    orderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                    orderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    orderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                    orderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                    orderModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    orderModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    orderModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    orderModel.UserName = Convert.ToString(rdr["UserName"]);
                    listOrderModel.Add(orderModel);
                }
                return listOrderModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetAll assíncrono " + ex.Message;
                this.logger.TraceException("GetAllOrdersAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public OrderModel GetById(int id)
        {
            OrderModel orderModel = new OrderModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_OrderGetById", con);
                cmd.Parameters.AddWithValue("@OrderId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    orderModel.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    orderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    orderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    orderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                    orderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    orderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                    orderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                    orderModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    orderModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    orderModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    orderModel.UserName = Convert.ToString(rdr["UserName"]);
                }
            }
            logger.Trace("GetById");
            return orderModel;
        }

        public async Task<OrderModel> GetByIdAsync(int id)
        {
            OrderModel orderModel = new OrderModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                SqlCommand cmd = new SqlCommand("USP_OrderGetById", con);
                cmd.Parameters.AddWithValue("@OrderId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    orderModel.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    orderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    orderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    orderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                    orderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    orderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                    orderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                    orderModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    orderModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    orderModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    orderModel.UserName = Convert.ToString(rdr["UserName"]);
                }
                logger.Trace("GetByIdAsync");
                return orderModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista os pedidos, utilizando a procedure USP_OrderGetById assíncrono " + ex.Message;
                this.logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(OrderModel orderModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_OrderInsert", con);
            cmd.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
            cmd.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
            cmd.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
            cmd.Parameters.AddWithValue("@Amount", orderModel.Amount);
            cmd.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", orderModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", orderModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(OrderModel orderModel)
        {
            try
            {
                this.logger.Trace("InsertAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_OrderInsert", con);
                cmd.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
                cmd.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
                cmd.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
                cmd.Parameters.AddWithValue("@Amount", orderModel.Amount);
                cmd.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", orderModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", orderModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();

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

                await productRepository.UpdateAsync(productModel);
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir um novo pedido, utilizando a procedure USP_OrderInsert assíncrono " + ex.Message;
                this.logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }


        public void Delete(int OrderId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_OrderDelete", con);
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int OrderId)
        {
            try
            {
                this.logger.Trace("DeleteAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_OrderDelete", con);
                cmd.Parameters.AddWithValue("@OrderId", OrderId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir o pedido, utilizando a procedure USP_OrderDelete assíncrono " + ex.Message;
                this.logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(OrderModel orderModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_OrderUpdate", con);
            cmd.Parameters.AddWithValue("@OrderId", orderModel.OrderId);
            cmd.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
            cmd.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
            cmd.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
            cmd.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
            cmd.Parameters.AddWithValue("@Amount", orderModel.Amount);
            cmd.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
            cmd.Parameters.AddWithValue("@DateInsert", orderModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", orderModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", orderModel.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(OrderModel orderModel)
        {
            try
            {
                this.logger.Trace("UpdateAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_OrderUpdate", con);
                cmd.Parameters.AddWithValue("@OrderId", orderModel.OrderId);
                cmd.Parameters.AddWithValue("@CommandId", orderModel.CommandId);
                cmd.Parameters.AddWithValue("@ProductId", orderModel.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", orderModel.ProductName);
                cmd.Parameters.AddWithValue("@SalePrice", orderModel.SalePrice);
                cmd.Parameters.AddWithValue("@Amount", orderModel.Amount);
                cmd.Parameters.AddWithValue("@TotalSalePrice", orderModel.TotalSalePrice);
                cmd.Parameters.AddWithValue("@DateInsert", orderModel.DateInsert);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", orderModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", orderModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar o pedido, utilizando a procedure USP_OrderUpdate assíncrono " + ex.Message;
                this.logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion
    }
}
