using Domain.Donne;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Donne
{
    public class OrderRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public OrderRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<OrderModel> GetAllOrders()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<OrderModel> listOrderModel = new List<OrderModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
            return listOrderModel;
        }

        public OrderModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            OrderModel orderModel = new OrderModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
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
            return orderModel;
        }

        public void Insert(OrderModel orderModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
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
        }

        public void Delete(int OrderId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_OrderDelete", con);
            cmd.Parameters.AddWithValue("@OrderId", OrderId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(OrderModel orderModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
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
        }

        #endregion
    }
}
