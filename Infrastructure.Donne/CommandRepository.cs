using System.Data.SqlClient;
using System.Data;
using Domain.Donne;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Donne
{
    public class CommandRepository
    {
        #region Properties
        private readonly IConfigurationRoot configurationRoot;
        #endregion

        #region Constructor
        public CommandRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<CommandModel> GetAllCommand()
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandModel command = new CommandModel();
                    command.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    command.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    command.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    command.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    command.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    command.UserId = Convert.ToInt32(rdr["UserId"]);
                    command.UserName = Convert.ToString(rdr["UserName"]);
                    command.Status = Convert.ToBoolean(rdr["Status"]);
                    listCommandsModel.Add(command);
                }
            }
            return listCommandsModel;
        }

        public IEnumerable<CommandModel> GetByStatus(int status)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandGetByStatus", con);
                cmd.Parameters.AddWithValue("@Status", status);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandModel commandModel = new CommandModel();
                    commandModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    commandModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    listCommandsModel.Add(commandModel);
                }
            }
            return listCommandsModel;
        }

        public IEnumerable<CommandOrderModel> GetCommandOrder(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<CommandOrderModel> listCommandsModel = new List<CommandOrderModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandOrdersById", con);
                cmd.Parameters.AddWithValue("@CommandId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CommandOrderModel commandOrderModel = new CommandOrderModel();
                    commandOrderModel.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    commandOrderModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    commandOrderModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    commandOrderModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    commandOrderModel.ProductName = Convert.ToString(rdr["ProductName"]);
                    commandOrderModel.Amount = Convert.ToInt32(rdr["Amount"]);
                    commandOrderModel.SalePrice = Convert.ToString(rdr["SalePrice"]);
                    commandOrderModel.TotalSalePrice = Convert.ToString(rdr["TotalSalePrice"]);
                    listCommandsModel.Add(commandOrderModel);
                }
            }
            return listCommandsModel;
        }

        public CommandModel GetById(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            CommandModel command = new CommandModel();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandsGetById", con);
                cmd.Parameters.AddWithValue("@CommandId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    command.CommandId = Convert.ToInt32(rdr["CommandId"]);
                    command.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    command.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    command.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    command.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    command.UserId = Convert.ToInt32(rdr["UserId"]);
                    command.UserName = Convert.ToString(rdr["UserName"]);
                    command.Status = Convert.ToBoolean(rdr["Status"]);
                }
            }
            return command;
        }

        public void Insert(CommandModel commandModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandInsert", con);
            cmd.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", commandModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", commandModel.UserName);
            cmd.Parameters.AddWithValue("@Status", 1);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int InsertReturnId(CommandModel commandModel)
        {
            int newId = 0;
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandInsertReturnId", con);
            cmd.Parameters.AddWithValue("@Identity", commandModel.CommandId);//OUTPUT
            cmd.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", commandModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", commandModel.UserName);
            cmd.Parameters.AddWithValue("@Status", true);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                newId = Convert.ToInt32(result);
            }
            con.Close();
            return newId;
        }

        public void Delete(int commandId)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandDelete", con);
            cmd.Parameters.AddWithValue("@CommandId", commandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Update(CommandModel commandModel)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandUpdate", con);
            cmd.Parameters.AddWithValue("@CommandId", commandModel.CommandId);
            cmd.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            cmd.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            cmd.Parameters.AddWithValue("@DateInsert", commandModel.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", commandModel.UserId);
            cmd.Parameters.AddWithValue("@UserName", commandModel.UserName);
            cmd.Parameters.AddWithValue("@Status", commandModel.Status);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        #endregion
    }
}
