using System.Data.SqlClient;
using System.Data;
using Domain.Donne;

namespace WebApi.Donne.Infrastructure
{
    public class FormOfPaymentRepository : BaseRepository
    {
        #region Constructor
        public FormOfPaymentRepository() : base() {}

        #endregion

        #region Methods 

        public IEnumerable<FormOfPaymentModel> GetAllFormOfPayment()
        {
            List<FormOfPaymentModel> listFormOfPaymentModel = new List<FormOfPaymentModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
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
            }
            return listFormOfPaymentModel;
        }

        public FormOfPaymentModel GetById(int id)
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
            return formOfPayment;
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
        }

        #endregion
    }
}
