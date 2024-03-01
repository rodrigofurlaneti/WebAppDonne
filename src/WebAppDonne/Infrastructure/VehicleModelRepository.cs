﻿using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class VehicleModelRepository : BaseRepository
    {
        #region Constructor

        public VehicleModelRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<VehicleModel> GetAllVehicleModels()
        {
            try
            {
                commandText = "USP_VehicleModelGetAll";
                List<VehicleModel> listVehicleModel = new List<VehicleModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleModel(sqlDataReader, listVehicleModel);
                    }
                }
                logger.Trace("GetAllVehicleModels");
                return listVehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            commandText = "USP_VehicleModelGetAll";
            List<VehicleModel> listVehicleModel = new List<VehicleModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                try
                {
                    logger.Trace("GetAllVehicleModelsAsync");
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetListVehicleModel(sqlDataReader, listVehicleModel);
                    }
                    return listVehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public VehicleModel GetById(int id)
        {
            try
            {
                commandText = "USP_VehicleModelGetAll";
                VehicleModel vehicleModel = new VehicleModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_VehicleModelGetById", sqlConnection);
                    GetSqlCommandVehicleModelById(sqlCommand, id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleModel(sqlDataReader, vehicleModel);
                    }
                }
                logger.Trace("GetById");
                return vehicleModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<VehicleModel> GetByIdAsync(int id)
        {
            commandText = "USP_VehicleModelGetAll";
            VehicleModel vehicleModel = new VehicleModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand sqlCommand = new SqlCommand("USP_VehicleModelGetById", sqlConnection))
                try
                {
                    logger.Trace("GetByIdAsync");
                    GetSqlCommandVehicleModelById(sqlCommand, id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                    while (sqlDataReader.Read())
                    {
                        GetVehicleModel(sqlDataReader, vehicleModel);
                    }
                    return vehicleModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_VehicleModelGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(VehicleModel vehicleModel)
        {
            commandText = "USP_VehicleModelInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleModelInsert(sqlCommand, vehicleModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(VehicleModel vehicleModel)
        {
            commandText = "USP_VehicleModelInsert";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleModelInsert(sqlCommand, vehicleModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("InsertAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Delete(int vehicleModelId)
        {
            commandText = "USP_VehicleModelDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleModelById(sqlCommand, vehicleModelId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int vehicleModelId)
        {
            commandText = "USP_VehicleModelDelete";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleModelById(sqlCommand, vehicleModelId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("DeleteAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        public void Update(VehicleModel vehicleModel)
        {
            commandText = "USP_VehicleModelGetAll";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicleModel.VehicleModelId);
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
            GetSqlCommandVehicleModelUpdate(sqlCommand, vehicleModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(VehicleModel vehicleModel)
        {
            commandText = "USP_VehicleModelUpdate";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
            GetSqlCommandVehicleModelUpdate(sqlCommand, vehicleModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            logger.Trace("UpdateAsync");
            await sqlCommand.ExecuteNonQueryAsync();
            sqlConnection.Close();
        }

        #endregion

        #region Helpers

        private List<VehicleModel> GetListVehicleModel(SqlDataReader sqlDataReader, List<VehicleModel> listVehicleModel)
        {
            VehicleModel vehicleModel = new VehicleModel();
            vehicleModel = GetVehicleModel(sqlDataReader, vehicleModel);
            listVehicleModel.Add(vehicleModel);
            return listVehicleModel;
        }

        private VehicleModel GetVehicleModel(SqlDataReader sqlDataReader, VehicleModel vehicleModel)
        {
            vehicleModel.VehicleModelId = Convert.ToInt32(sqlDataReader["VehicleModelId"]);
            vehicleModel.VehicleModelName = Convert.ToString(sqlDataReader["VehicleModelName"]);
            return vehicleModel;
        }

        private void GetSqlCommandVehicleModelById(SqlCommand sqlCommand, int vehicleModelId)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleModelId", vehicleModelId);
        }

        private void GetSqlCommandVehicleModelInsert(SqlCommand sqlCommand, VehicleModel vehicleModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleModelName", vehicleModel.VehicleModelName);
        }

        private void GetSqlCommandVehicleModelUpdate(SqlCommand sqlCommand, VehicleModel vehicleModel)
        {
            sqlCommand.Parameters.AddWithValue("@VehicleId", vehicleModel.VehicleModelId);
            sqlCommand.Parameters.AddWithValue("@VehicleName", vehicleModel.VehicleModelName);
        }


        #endregion

    }
}