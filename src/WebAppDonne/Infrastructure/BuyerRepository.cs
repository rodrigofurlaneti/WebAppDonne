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
                logger.Trace("GetAllBuyers");
                List<BuyerModel> listBuyerModel = new List<BuyerModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BuyerGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BuyerModel buyerModel = new BuyerModel();
                        buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                        buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                        buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                        buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                        buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                        listBuyerModel.Add(buyerModel);
                    }
                }
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<BuyerModel>> GetAllBuyersAsync()
        {
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BuyerGetAll", con))
            try
            {
                logger.Trace("GetAllBuyersAsync");
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    BuyerModel buyerModel = new BuyerModel();
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                    buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                    listBuyerModel.Add(buyerModel);
                }
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetAll assíncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public IEnumerable<BuyerModel> GetByStatus(int status)
        {
            try
            {
                logger.Trace("GetByStatus");
                List<BuyerModel> listBuyerModel = new List<BuyerModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BuyerGetStatus", con);
                    cmd.Parameters.AddWithValue("@Status", status);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        BuyerModel buyerModel = new BuyerModel();
                        buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                        buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                        buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                        buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                        buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                        listBuyerModel.Add(buyerModel);
                    }
                }
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_GetByStatus síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<BuyerModel>> GetByStatusAsync(int status)
        {
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BuyerGetStatus", con))
            try
            {
                logger.Trace("GetByStatusAsync");
                cmd.Parameters.AddWithValue("@Status", status);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    BuyerModel buyerModel = new BuyerModel();
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                    buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                    listBuyerModel.Add(buyerModel);
                }
                return listBuyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetStatus, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public BuyerModel GetById(int id)
        {
            try
            {
                logger.Trace("GetById");
                BuyerModel buyerModel = new BuyerModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_BuyerGetById", con);
                    cmd.Parameters.AddWithValue("@BuyerId", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                        buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                        buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                        buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                        buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                        buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                        buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                        buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                    }
                }
                return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<BuyerModel> GetByIdAsync(int id)
        {
            BuyerModel buyerModel = new BuyerModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BuyerGetById", con))
            try
            {
                logger.Trace("GetByIdAsync");
                cmd.Parameters.AddWithValue("@BuyerId", id);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    buyerModel.BuyerId = Convert.ToInt32(rdr["BuyerId"]);
                    buyerModel.BuyerName = Convert.ToString(rdr["BuyerName"]);
                    buyerModel.BuyerPhone = Convert.ToString(rdr["BuyerPhone"]);
                    buyerModel.BuyerAddress = Convert.ToString(rdr["BuyerAddress"]);
                    buyerModel.DateInsert = Convert.ToDateTime(rdr["DateInsert"]);
                    buyerModel.DateUpdate = Convert.ToDateTime(rdr["DateUpdate"]);
                    buyerModel.UserId = Convert.ToInt32(rdr["UserId"]);
                    buyerModel.UserName = Convert.ToString(rdr["UserName"]);
                }

                    return buyerModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetId, assíncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }
        }

        public void Insert(BuyerModel buyerModel)
        {
                logger.Trace("Insert");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_BuyerInsert", con);
                cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
                cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
                cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
                cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
        }

        public void InsertAsync(BuyerModel buyerModel)
        {
                logger.Trace("InsertAsync");
                Task.Run(() =>
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("USP_BuyerInsert", con);
                    cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
                    cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
                    cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
                    cmd.Parameters.AddWithValue("@DateInsert", DateTime.Now);
                    cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
                    cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();
                });
        }

        public void Delete(int buyerId)
        {
                logger.Trace("Delete");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_BuyerDelete", con);
                cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
        }

        public void DeleteAsync(int buyerId)
        {
                logger.Trace("DeleteAsync");
                Task.Run(() => {
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("USP_BuyerDelete", con);
                    cmd.Parameters.AddWithValue("@BuyerId", buyerId);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    con.Close();
                });
        }

        public void Update(BuyerModel buyerModel)
        {
                logger.Trace("Update");
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
                cmd.Parameters.AddWithValue("@BuyerId", buyerModel.BuyerId);
                cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
                cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
                cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
                cmd.Parameters.AddWithValue("@DateInsert", buyerModel.DateInsert);
                cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
                cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                con.Close();
        }

        public void UpdateAsync(BuyerModel buyerModel)
        {
            logger.Trace("UpdateAsync");
            Task.Run(() => {
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
                    cmd.Parameters.AddWithValue("@BuyerId", buyerModel.BuyerId);
                    cmd.Parameters.AddWithValue("@BuyerName", buyerModel.BuyerName);
                    cmd.Parameters.AddWithValue("@BuyerPhone", buyerModel.BuyerPhone);
                    cmd.Parameters.AddWithValue("@BuyerAddress", buyerModel.BuyerAddress);
                    cmd.Parameters.AddWithValue("@DateInsert", buyerModel.DateInsert);
                    cmd.Parameters.AddWithValue("@DateUpdate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@UserId", buyerModel.UserId);
                    cmd.Parameters.AddWithValue("@UserName", buyerModel.UserName);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQueryAsync();
                    con.Close();
                });
        }

        #endregion
    }
}
