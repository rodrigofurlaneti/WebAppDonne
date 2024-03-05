using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure.Command
{
    public class CommandRepository : BaseRepository, ICommandRepository
    {
        #region Constructor

        public CommandRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<CommandModel> GetAll()
        {
            commandText = "USP_Donne_Command_GetAll";
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListCommandModel(sqlDataReader, listCommandsModel);
                }
            }
            logger.Trace("Command_GetAll");
            return listCommandsModel;
        }

        public async Task<IEnumerable<CommandModel>> GetAllAsync()
        {
            commandText = "USP_Donne_Command_GetAll";
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListCommandModel(sqlDataReader, listCommandsModel);
                    }
                    logger.Trace("Command_GetAllAsync");
                    return listCommandsModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro ao lista as comandas, utilizando a procedure USP_Donne_Command_GetAll assíncrono " + ex.Message;
                    logger.TraceException("Command_GetAllAsync");
                    throw new ArgumentNullException(mensagemErro);
                }

        }

        public IEnumerable<CommandModel> GetByStatus(int status)
        {
            commandText = "USP_Donne_Command_GetByStatus";
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Status", status);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetListCommandModel(sqlDataReader, listCommandsModel);
                }
            }
            logger.Trace("GetByStatus");
            return listCommandsModel;
        }

        public async Task<IEnumerable<CommandModel>> GetByStatusAsync(int status)
        {
            commandText = "USP_Donne_Command_GetByStatus";
            List<CommandModel> listCommandsModel = new List<CommandModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Status", status);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListCommandModel(sqlDataReader, listCommandsModel);
                    }
                    logger.Trace("Command_GetByStatusAsync");
                    return listCommandsModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro procurar status da comanda, utilizando a procedure USP_CommandGetByStatus assíncrono " + ex.Message;
                    logger.TraceException("Command_GetByStatusAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public CommandModel GetById(int id)
        {
            commandText = "USP_Donne_Command_GetById";
            CommandModel commandModel = new CommandModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CommandId", id);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    GetCommandModel(sqlDataReader, commandModel);
                }
            }
            logger.Trace("Command_GetById");
            return commandModel;
        }

        public async Task<CommandModel> GetByIdAsync(int id)
        {
            CommandModel commandModel = new CommandModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    commandText = "USP_Donne_Command_GetById";
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@CommandId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetCommandModel(sqlDataReader, commandModel);
                    }
                    logger.Trace("Command_GetByIdAsync");
                    return commandModel;
                }
                catch (Exception ex)
                {
                    string mensagemErro = "Erro procurar id da comanda, utilizando a procedure USP_Donne_Command_GetById assíncrono " + ex.Message;
                    logger.TraceException("Command_GetByIdAsync");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(CommandModel commandModel)
        {
            commandText = "USP_Donne_Command_Insert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandCommandModelInsert(sqlCommand, commandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Command_Insert");
        }

        public async Task InsertAsync(CommandModel commandModel)
        {
            try
            {
                commandText = "USP_Donne_Command_Insert";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandCommandModelInsert(sqlCommand, commandModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Command_InsertAsync");
            }
            catch (Exception ex)
            {
                logger.TraceException("Command_InsertAsync");
                string mensagemErro = "Erro ao inserir da comanda, utilizando a procedure USP_CommandInsert assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public int InsertReturnId(CommandModel commandModel)
        {
            commandText = "USP_Donne_Command_InsertReturnId";
            int newId = 0;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandCommandModelInsertReturnId(sqlCommand, commandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var result = sqlCommand.ExecuteScalar();
            if (result != null)
            {
                newId = Convert.ToInt32(result);
            }
            sqlConnection.Close();
            logger.Trace("Command_InsertReturnId");
            return newId;
        }

        public async Task<int> InsertReturnIdAsync(CommandModel commandModel)
        {
            try
            {
                commandText = "USP_Donne_Command_InsertReturnId";
                logger.Trace("InsertReturnIdAsync");
                int newId = 0;
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandCommandModelInsertReturnId(sqlCommand, commandModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var result = await sqlCommand.ExecuteScalarAsync();
                if (result != null)
                {
                    newId = Convert.ToInt32(result);
                }
                sqlConnection.Close();
                return newId;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir da comanda, retorno id, utilizando a procedure USP_Donne_Command_InsertReturnId assíncrono " + ex.Message;
                logger.TraceException("Command_InsertReturnIdAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Delete(int commandId)
        {
            commandText = "USP_Donne_Command_Delete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CommandId", commandId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Command_Delete");
        }

        public async Task DeleteAsync(int commandId)
        {
            try
            {
                commandText = "USP_Donne_Command_Delete";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CommandId", commandId);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Command_DeleteAsync");
            }
            catch (Exception ex)
            {
                logger.TraceException("Command_DeleteAsync");
                string mensagemErro = "Erro ao excluir uma comanda, utilizando a procedure USP_Donne_Command_Delete assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }


        public void Update(CommandModel commandModel)
        {
            commandText = "USP_Donne_Command_Update";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandCommandModelUpdate(sqlCommand, commandModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Command_Update");
        }

        public async Task UpdateAsync(CommandModel commandModel)
        {
            try
            {
                commandText = "USP_Donne_Command_Update";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                GetSqlCommandCommandModelUpdate(sqlCommand, commandModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                logger.Trace("Command_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualzar uma comanda, utilizando a procedure USP_Donne_Command_Update assíncrono " + ex.Message;
                logger.TraceException("Command_UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        #endregion

        #region Helpers
        private static void GetListCommandModel(SqlDataReader sqlDataReader, List<CommandModel> listCommandModel)
        {
            CommandModel commandModel = new CommandModel();
            GetCommandModel(sqlDataReader, commandModel);
            listCommandModel.Add(commandModel);
        }

        private static void GetCommandModel(SqlDataReader sqlDataReader, CommandModel commandModel)
        {
            commandModel.CommandId = Convert.ToInt32(sqlDataReader["CommandId"]);
            commandModel.BuyerId = Convert.ToInt32(sqlDataReader["BuyerId"]);
            commandModel.BuyerName = Convert.ToString(sqlDataReader["BuyerName"]);
            commandModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            commandModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            commandModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            commandModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            commandModel.Status = Convert.ToInt32(sqlDataReader["Status"]);
        }

        private static void GetSqlCommandCommandModelInsert(SqlCommand sqlCommand, CommandModel commandModel)
        {
            sqlCommand.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            sqlCommand.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", commandModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", commandModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", commandModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", commandModel.Status);
        }

        private static void GetSqlCommandCommandModelInsertReturnId(SqlCommand sqlCommand, CommandModel commandModel)
        {
            sqlCommand.Parameters.AddWithValue("@Identity", commandModel.CommandId);//OUTPUT
            sqlCommand.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            sqlCommand.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", commandModel.DateUpdate);
            sqlCommand.Parameters.AddWithValue("@UserId", commandModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", commandModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", commandModel.Status);
        }

        private static void GetSqlCommandCommandModelUpdate(SqlCommand sqlCommand, CommandModel commandModel)
        {
            sqlCommand.Parameters.AddWithValue("@CommandId", commandModel.CommandId);
            sqlCommand.Parameters.AddWithValue("@BuyerId", commandModel.BuyerId);
            sqlCommand.Parameters.AddWithValue("@BuyerName", commandModel.BuyerName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", commandModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", commandModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", commandModel.UserName);
            sqlCommand.Parameters.AddWithValue("@Status", commandModel.Status);
        }

        #endregion
    }
}
