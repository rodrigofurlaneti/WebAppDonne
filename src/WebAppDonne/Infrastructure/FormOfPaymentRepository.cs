﻿using System.Data.SqlClient;
using System.Data;
using Domain.Donne;
using System.Collections.Generic;

namespace WebApi.Donne.Infrastructure
{
    public class FormOfPaymentRepository : BaseRepository
    {
        #region Constructor

        public FormOfPaymentRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<FormOfPaymentModel> GetAllFormOfPayment()
        {
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_GetAll", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListFormOfPaymentModel(sqlDataReader, listFormOfPaymentModel);
                    }
                    this.logger.Trace("FormOfPayment_GetAll");
                    return listFormOfPaymentModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_FormOfPaymentGetAll síncrono " + ex.Message;
                    this.logger.TraceException("FormOfPayment_GetAll");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<FormOfPaymentModel>> GetAllFormOfPaymentAsync()
        {
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_GetAll", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                while (sqlDataReader.Read())
                {
                    GetListFormOfPaymentModel(sqlDataReader, listFormOfPaymentModel);
                }
                this.logger.Trace("GetAllFormOfPaymentAsync");
                return listFormOfPaymentModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_FormOfPaymentGetAll assíncrono " + ex.Message;
                this.logger.TraceException("GetAllFormOfPaymentAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public FormOfPaymentModel GetById(int id)
        {
            try
            {
                FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_GetById", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", id);
                    sqlConnection.Open();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetFormOfPaymentModel(sqlDataReader, formOfPaymentModel);
                    }
                }
                this.logger.Trace("FormOfPayment_GetById");
                return formOfPaymentModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_GetById síncrono " + ex.Message;
                this.logger.TraceException("FormOfPayment_GetById");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<FormOfPaymentModel> GetByIdAsync(int id)
        {
            FormOfPaymentModel formOfPaymentModel = new FormOfPaymentModel();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            try
            {
               SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_GetById", sqlConnection);
               sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", id);
               sqlConnection.Open();
               sqlCommand.CommandType = CommandType.StoredProcedure;
               SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
               while (sqlDataReader.Read())
               {
                    GetFormOfPaymentModel(sqlDataReader, formOfPaymentModel);
               }
               this.logger.Trace("FormOfPayment_GetByIdAsync");
               return formOfPaymentModel;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_GetById síncrono " + ex.Message;
                this.logger.TraceException("FormOfPayment_GetByIdAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(FormOfPaymentModel formOfPaymentModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_Insert", sqlConnection);
            GetSqlCommandBuyerModelInsert(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("FormOfPayment_Insert");
        }

        public async Task InsertAsync(FormOfPaymentModel formOfPaymentModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_Insert", sqlConnection);
                GetSqlCommandBuyerModelInsert(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                this.logger.Trace("FormOfPayment_InsertAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir uma nova forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Insert assíncrono " + ex.Message;
                this.logger.TraceException("FormOfPayment_InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int formOfPaymentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_Donne_FormOfPayment_Delete", con);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("FormOfPayment_Delete");
        }

        public async Task DeleteAsync(int formOfPaymentId)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_Donne_FormOfPayment_Delete", con);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
                this.logger.Trace("FormOfPayment_DeleteAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir uma forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Delete assíncrono " + ex.Message;
                this.logger.TraceException("FormOfPayment_DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(FormOfPaymentModel formOfPaymentModel)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_Update", sqlConnection);
            GetSqlCommandBuyerModelUpdate(sqlCommand, formOfPaymentModel);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logger.Trace("FormOfPayment_Update");
        }

        public async Task UpdateAsync(FormOfPaymentModel formOfPaymentModel)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand("USP_Donne_FormOfPayment_Update", sqlConnection);
                GetSqlCommandBuyerModelUpdate(sqlCommand, formOfPaymentModel);
                sqlConnection.Open();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                await sqlCommand.ExecuteNonQueryAsync();
                sqlConnection.Close();
                this.logger.Trace("FormOfPayment_UpdateAsync");
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma forma de pagamento, utilizando a procedure USP_Donne_FormOfPayment_Update assíncrono " + ex.Message;
                this.logger.TraceException("FormOfPayment_UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion

        #region Helpers
        private List<FormOfPaymentModel> GetListFormOfPaymentModel(SqlDataReader sqlDataReader, List<FormOfPaymentModel> listFormOfPaymentModel)
        {
            FormOfPaymentModel FormOfPaymentModel = new FormOfPaymentModel();
            FormOfPaymentModel = GetFormOfPaymentModel(sqlDataReader, FormOfPaymentModel);
            listFormOfPaymentModel.Add(FormOfPaymentModel);
            return listFormOfPaymentModel;
        }

        private FormOfPaymentModel GetFormOfPaymentModel(SqlDataReader sqlDataReader, FormOfPaymentModel formOfPaymentModel)
        {
            formOfPaymentModel.FormOfPaymentId = Convert.ToInt32(sqlDataReader["FormOfPaymentId"]);
            formOfPaymentModel.FormOfPaymentName = Convert.ToString(sqlDataReader["FormOfPaymentName"]);
            formOfPaymentModel.DateInsert = Convert.ToDateTime(sqlDataReader["DateInsert"]);
            formOfPaymentModel.DateUpdate = Convert.ToDateTime(sqlDataReader["DateUpdate"]);
            formOfPaymentModel.UserId = Convert.ToInt32(sqlDataReader["UserId"]);
            formOfPaymentModel.UserName = Convert.ToString(sqlDataReader["UserName"]);
            return formOfPaymentModel;
        }

        private void GetSqlCommandBuyerModelInsert(SqlCommand sqlCommand, FormOfPaymentModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", formOfPaymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", formOfPaymentModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        private void GetSqlCommandBuyerModelUpdate(SqlCommand sqlCommand, FormOfPaymentModel formOfPaymentModel)
        {
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentId", formOfPaymentModel.FormOfPaymentId);
            sqlCommand.Parameters.AddWithValue("@FormOfPaymentName", formOfPaymentModel.FormOfPaymentName);
            sqlCommand.Parameters.AddWithValue("@DateInsert", formOfPaymentModel.DateInsert);
            sqlCommand.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            sqlCommand.Parameters.AddWithValue("@UserId", formOfPaymentModel.UserId);
            sqlCommand.Parameters.AddWithValue("@UserName", formOfPaymentModel.UserName);
        }

        #endregion
    }
}
