using Domain.Donne;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Donne.Infrastructure
{
    public class BuyerRepository : BaseRepository
    {
        #region Constructor

        public BuyerRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<BuyerModel> GetAllBuyers()
        {
            try
            {
                commandText = "USP_Donne_Buyer_GetAll";
                List<BuyerModel> listBuyerModel = new List<BuyerModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListBuyerModel(sqlDataReader, listBuyerModel);
                    }
                }
                logger.Trace("Buyer_GetAll");
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<IEnumerable<BuyerModel>> GetAllBuyersAsync()
        {
            commandText = "USP_Donne_Buyer_GetAll";
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
            try
            {

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    GetListBuyerModel(sqlDataReader, listBuyerModel);
                }
                logger.Trace("Buyer_GetAllAsync");
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetAll assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public IEnumerable<BuyerModel> GetByStatus(int status)
        {
            try
            {
                commandText = "USP_Donne_Buyer_GetStatus";
                List<BuyerModel> listBuyerModel = new List<BuyerModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Status", status);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListBuyerModel(sqlDataReader, listBuyerModel);
                    }
                }
                logger.Trace("Buyer_GetByStatus");
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<BuyerModel>> GetByStatusAsync(int status)
        {
            commandText = "USP_Donne_Buyer_GetStatus";
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
            try
            {
                sqlCommand.Parameters.AddWithValue("@Status", status);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    GetListBuyerModel(sqlDataReader, listBuyerModel);
                }
                logger.Trace("Buyer_GetByStatusAsync");
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetStatus, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public BuyerModel GetById(int id)
        {
            try
            {
                commandText = "USP_Donne_Buyer_GetId";
                BuyerModel buyerModel = new BuyerModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@BuyerId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        buyerModel = GetBuyerModel(sqlDataReader, buyerModel);
                    }
                }
                logger.Trace("Buyer_GetById");
                return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<BuyerModel> GetByIdAsync(int id)
        {
            commandText = "USP_Donne_Buyer_GetId";
            BuyerModel buyerModel = new BuyerModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
            try
            {
                sqlCommand.Parameters.AddWithValue("@BuyerId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    buyerModel = GetBuyerModel(sqlDataReader, buyerModel);
                }
                logger.Trace("Buyer_GetByIdAsync");
                return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Donne_Buyer_GetId, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(BuyerModel buyerModel)
        {
            commandText = "USP_Donne_Buyer_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelInsert(sqlCommand, buyerModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Buyer_Insert");
        }

        public async Task InsertAsync(BuyerModel buyerModel)
        {
            commandText = "USP_Donne_Buyer_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelInsert(sqlCommand, buyerModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("Buyer_InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int buyerId)
        {
            commandText = "USP_Donne_Buyer_Delete";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(commandText, con);
            cmd.Parameters.AddWithValue("@BuyerId", buyerId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Buyer_Delete");
        }

        public async Task DeleteAsync(int buyerId)
        {
            commandText = "USP_Donne_Buyer_Delete";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(commandText, con);
            cmd.Parameters.AddWithValue("@BuyerId", buyerId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            logger.Trace("Buyer_DeleteAsync");
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(BuyerModel buyerModel)
        {
            commandText = "USP_Donne_Buyer_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelUpdate(sqlCommand, buyerModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Buyer_Update");
        }

        public async Task UpdateAsync(BuyerModel buyerModel)
        {
            commandText = "USP_Donne_Buyer_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandBuyerModelUpdate(sqlCommand, buyerModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("Buyer_UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        #endregion

        #region Helpers
        private List<BuyerModel> GetListBuyerModel(SqlDataReader sqlDataReader, List<BuyerModel> listBuyerModel)
        {
            BuyerModel buyerModel = new BuyerModel();
            buyerModel = GetBuyerModel(sqlDataReader, buyerModel);
            listBuyerModel.Add(buyerModel);
            return listBuyerModel;
        }

        private BuyerModel GetBuyerModel(SqlDataReader sqlDataReader, BuyerModel buyerModel)
        {
            buyerModel.BuyerId = Convert.ToInt32(sqlDataReader["BuyerId"]);
            buyerModel.BuyerName = Convert.ToString(sqlDataReader["BuyerName"]);
            buyerModel.BuyerPhone = Convert.ToString(sqlDataReader["BuyerPhone"]);
            buyerModel.BuyerAddress = Convert.ToString(sqlDataReader["BuyerAddress"]);
            buyerModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            buyerModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            buyerModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            buyerModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            return buyerModel;
        }

        private void GetSqlCommandBuyerModelInsert(SqlCommand sqlCommand, BuyerModel buyerModel)
        {
            sqlCommand.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
            sqlCommand.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
            sqlCommand.Parameters.AddWithValue("@DateInsert", buyerModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", buyerModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", buyerModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", buyerModel.Status);
        }

        private void GetSqlCommandBuyerModelUpdate(SqlCommand sqlCommand, BuyerModel buyerModel)
        {
            sqlCommand.Parameters.AddWithValue("@BuyerId", buyerModel.BuyerId);
            sqlCommand.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
            sqlCommand.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
            sqlCommand.Parameters.AddWithValue("@DateInsert", buyerModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", buyerModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", buyerModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", buyerModel.Status);
        }

        #endregion
    }
}
