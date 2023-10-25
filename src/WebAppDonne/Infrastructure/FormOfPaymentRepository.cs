using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

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
            using (SqlConnection con = new SqlConnection(connectionString))
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_FormOfPaymentGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FormOfPaymentModel formOfPayment = new FormOfPaymentModel();
                        formOfPayment.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                        formOfPayment.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                        formOfPayment.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        formOfPayment.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        formOfPayment.UserId = Convert.ToInt32(rdr["UserId"]);
                        formOfPayment.UserName = Convert.ToString(rdr["UserName"]);
                        listFormOfPaymentModel.Add(formOfPayment);
                    }
                    this.logger.Trace("GetAllFormOfPayment");
                    return listFormOfPaymentModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao lista as formas de pagamentos, utilizando a procedure USP_FormOfPaymentGetAll síncrono " + ex.Message;
                    this.logger.TraceException("GetAllFormOfPayment");
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public async Task<IEnumerable<FormOfPaymentModel>> GetAllFormOfPaymentAsync()
        {
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
                this.logger.Trace("GetAllFormOfPaymentAsync");
                SqlCommand cmd = new SqlCommand("USP_FormOfPaymentGetAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    FormOfPaymentModel formOfPayment = new FormOfPaymentModel();
                    formOfPayment.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    formOfPayment.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    formOfPayment.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    formOfPayment.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    formOfPayment.UserId = Convert.ToInt32(rdr["UserId"]);
                    formOfPayment.UserName = Convert.ToString(rdr["UserName"]);
                    listFormOfPaymentModel.Add(formOfPayment);
                }
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
                FormOfPaymentModel formOfPayment = new FormOfPaymentModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_FormOfPaymentGetById", con);
                    cmd.Parameters.AddWithValue("@FormOfPaymentId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        formOfPayment.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                        formOfPayment.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                        formOfPayment.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        formOfPayment.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        formOfPayment.UserId = Convert.ToInt32(rdr["UserId"]);
                        formOfPayment.UserName = Convert.ToString(rdr["UserName"]);
                    }
                }
                this.logger.Trace("GetById");
                return formOfPayment;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_FormOfPaymentGetById síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public async Task<FormOfPaymentModel> GetByIdAsync(int id)
        {
            FormOfPaymentModel formOfPayment = new FormOfPaymentModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            try
            {
               this.logger.Trace("GetByIdAsync");
               SqlCommand cmd = new SqlCommand("USP_FormOfPaymentGetById", con);
               cmd.Parameters.AddWithValue("@FormOfPaymentId", id);
               con.Open();
               cmd.CommandType = CommandType.StoredProcedure;
               SqlDataReader rdr = await cmd.ExecuteReaderAsync();
               while (rdr.Read())
               {
                    formOfPayment.FormOfPaymentId = Convert.ToInt32(rdr["FormOfPaymentId"]);
                    formOfPayment.FormOfPaymentName = Convert.ToString(rdr["FormOfPaymentName"]);
                    formOfPayment.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    formOfPayment.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    formOfPayment.UserId = Convert.ToInt32(rdr["UserId"]);
                    formOfPayment.UserName = Convert.ToString(rdr["UserName"]);
               }
               return formOfPayment;
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao lista a forma de pagamento, utilizando a procedure USP_FormOfPaymentGetById síncrono " + ex.Message;
                this.logger.TraceException("GetByIdAsync");
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(FormOfPaymentModel FormOfPayment)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_FormOfPaymentInsert", con);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", FormOfPayment.FormOfPaymentName);
            cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", FormOfPayment.UserId);
            cmd.Parameters.AddWithValue("@UserName", FormOfPayment.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Insert");
        }

        public async Task InsertAsync(FormOfPaymentModel FormOfPayment)
        {
            try
            {
                this.logger.Trace("InsertAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_FormOfPaymentInsert", con);
                cmd.Parameters.AddWithValue("@FormOfPaymentName", FormOfPayment.FormOfPaymentName);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", FormOfPayment.UserId);
                cmd.Parameters.AddWithValue("@UserName", FormOfPayment.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao inserir uma nova forma de pagamento, utilizando a procedure USP_FormOfPaymentInsert assíncrono " + ex.Message;
                this.logger.TraceException("InsertAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Delete(int FormOfPaymentId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_FormOfPaymentDelete", con);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", FormOfPaymentId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Delete");
        }

        public async Task DeleteAsync(int FormOfPaymentId)
        {
            try
            {
                this.logger.Trace("DeleteAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_FormOfPaymentDelete", con);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", FormOfPaymentId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao excluir uma forma de pagamento, utilizando a procedure USP_FormOfPaymentDelete assíncrono " + ex.Message;
                this.logger.TraceException("DeleteAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public void Update(FormOfPaymentModel FormOfPayment)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_FormOfPaymentUpdate", con);
            cmd.Parameters.AddWithValue("@FormOfPaymentId", FormOfPayment.FormOfPaymentId);
            cmd.Parameters.AddWithValue("@FormOfPaymentName", FormOfPayment.FormOfPaymentName);
            cmd.Parameters.AddWithValue("@DateInsert", FormOfPayment.DateInsert);
            cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@UserId", FormOfPayment.UserId);
            cmd.Parameters.AddWithValue("@UserName", FormOfPayment.UserName);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            logger.Trace("Update");
        }

        public async Task UpdateAsync(FormOfPaymentModel FormOfPayment)
        {
            try
            {
                this.logger.Trace("UpdateAsync");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_FormOfPaymentUpdate", con);
                cmd.Parameters.AddWithValue("@FormOfPaymentId", FormOfPayment.FormOfPaymentId);
                cmd.Parameters.AddWithValue("@FormOfPaymentName", FormOfPayment.FormOfPaymentName);
                cmd.Parameters.AddWithValue("@DateInsert", FormOfPayment.DateInsert);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", FormOfPayment.UserId);
                cmd.Parameters.AddWithValue("@UserName", FormOfPayment.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
            catch (Exception ex)
            {
                string mensagemErro = "Erro ao atualizar uma forma de pagamento, utilizando a procedure USP_FormOfPaymentUpdate assíncrono " + ex.Message;
                this.logger.TraceException("UpdateAsync");
                throw new ArgumentNullException(mensagemErro);
            }

        }

        #endregion
    }
}
