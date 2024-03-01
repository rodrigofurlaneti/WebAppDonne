using Domain.Donne;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleColorRepository : BaseRepository
    {
        #region Constructor

        public VehicleColorRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleColorModel> GetAllVehicleColors()
        {
            try
            {
                commandText = "USP_VehicleColorGetAll";
                List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleColorModel(sqlDataReader, listColorModel);
                    }
                }
                logger.Trace("GetAllVehicleColors");
                return listColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<VehicleColorModel>> GetAllVehicleColorsAsync()
        {
            commandText = "USP_VehicleColorGetAlll";
            List<VehicleColorModel> listColorModel = new List<VehicleColorModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetAllVehicleColorsAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleColorModel(sqlDataReader, listColorModel);
                    }
                    return listColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleColorModel GetById(int id)
        {
            try
            {
                commandText = "USP_VehicleColorGetById";
                VehicleColorModel vehicleColorModel = new VehicleColorModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleColorModel(sqlDataReader, vehicleColorModel);
                    }
                }
                logger.Trace("GetById");
                return vehicleColorModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleColorModel> GetByIdAsync(int id)
        {
            commandText = "USP_VehicleColorGetById";
            VehicleColorModel vehicleColorModel = new VehicleColorModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetByIdAsync");
                    sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleColorModel(sqlDataReader, vehicleColorModel);
                    }
                    return vehicleColorModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleColorGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleColorModel vehicleColorModel)
        {
            commandText = "USP_VehicleColorInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelInsert(sqlCommand, vehicleColorModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleColorModel vehicleColorModel)
        {
            commandText = "USP_VehicleColorInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelInsert(sqlCommand, vehicleColorModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int colorId)
        {
            commandText = "USP_VehicleColorDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelDelete(sqlCommand, colorId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int colorId)
        {
            commandText = "USP_VehicleColorDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelDelete(sqlCommand, colorId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Update(VehicleColorModel vehicleColorModel)
        {
            commandText = "USP_VehicleColorUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelUpdate(sqlCommand, vehicleColorModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(VehicleColorModel vehicleColorModel)
        {
            commandText = "USP_VehicleColorUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand  = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleColorModelUpdate(sqlCommand, vehicleColorModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        #endregion

        #region Helpers

        private List<VehicleColorModel> GetListVehicleColorModel(SqlDataReader sqlDataReader, List<VehicleColorModel> listVehicleColorModel)
        {
            VehicleColorModel vehicleColorModel = new VehicleColorModel();
            vehicleColorModel = GetVehicleColorModel(sqlDataReader, vehicleColorModel);
            listVehicleColorModel.Add(vehicleColorModel);
            return listVehicleColorModel;
        }

        private VehicleColorModel GetVehicleColorModel(SqlDataReader sqlDataReader, VehicleColorModel vehicleColorModel)
        {
            vehicleColorModel.VehicleColorId = Convert.ToInt32(sqlDataReader["VehicleColorId"]);
            vehicleColorModel.VehicleColorName = Convert.ToString(sqlDataReader["VehicleColorName"]);
            return vehicleColorModel;
        }

        private void GetSqlCommandVehicleColorModelInsert(SqlCommand sqlCommand, VehicleColorModel vehicleColorModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
        }

        private void GetSqlCommandVehicleColorModelDelete(SqlCommand sqlCommand, int id)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", id);
        }

        private void GetSqlCommandVehicleColorModelUpdate(SqlCommand sqlCommand, VehicleColorModel vehicleColorModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleColorId", vehicleColorModel.VehicleColorId);
            sqlCommand.Parameters.AddWithValue("@VehicleColorName", vehicleColorModel.VehicleColorName);
        }

        #endregion
    }
}