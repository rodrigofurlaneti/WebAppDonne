using System.Data.SqlClient;
using System.Data;
using WebAppDonne.Models;

namespace WebAppDonne.Dal
{
    public class BuyerStatusRepository
    {
        #region Properties

        private readonly IConfigurationRoot configurationRoot;

        #endregion

        #region Constructor
        public BuyerStatusRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
        }
        #endregion

        #region Methods 

        public IEnumerable<BuyerModel> GetStatus(int id)
        {
            string ConnectionString = configurationRoot.GetConnectionString("localHost");
            List<BuyerModel> listBuyerModel = new List<BuyerModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("USP_BuyerGetStatus", con);
                cmd.Parameters.AddWithValue("@Status", id);
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

        #endregion
    }
}
