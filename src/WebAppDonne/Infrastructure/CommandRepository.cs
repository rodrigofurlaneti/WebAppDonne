using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure
{
    public class CommandRepository : BaseRepository
    {
        #region Constructor

        public CommandRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<CommandModel> GetAllCommand()
        {
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
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
            logger.Trace("GetAllCommand");
            return listCommandsModel;
        }

        public IEnumerable<CommandModel> GetByStatus(int status)
        {
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
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
            logger.Trace("GetByStatus");
            return listCommandsModel;
        }

        public IEnumerable<CommandOrderModel> GetCommandOrder(int id)
        {
            List<CommandOrderModel> listCommandsModel = new List<CommandOrderModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
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
            logger.Trace("GetCommandOrder");
            return listCommandsModel;
        }

        public CommandModel GetById(int id)
        {
            CommandModel command = new CommandModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_CommandGetById", con);
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
            logger.Trace("GetById");
            return command;
        }

        public void Insert(CommandModel commandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
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
            logger.Trace("Insert");
        }

        public int InsertReturnId(CommandModel commandModel)
        {
            int newId = 0;
            SqlConnection con = new SqlConnection(connectionString);
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
            logger.Trace("InsertReturnId");
            return newId;
        }

        public void Delete(int commandId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_CommandDelete", con);
            cmd.Parameters.AddWithValue("@CommandId", commandId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public void Update(CommandModel commandModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
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
            logger.Trace("Update");
        }

        #endregion
    }
}
