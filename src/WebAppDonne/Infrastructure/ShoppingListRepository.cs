using Domain.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure
{
    public class ShoppingListRepository : BaseRepository
    {
        #region Constructor

        public ShoppingListRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<ShoppingListModel> GetAllShoppingList()
        {
            try
            {
                List<ShoppingListModel> listShoppingListModel = new List<ShoppingListModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_ShoppingListGetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ShoppingListModel shoppingListModel = new ShoppingListModel();
                        shoppingListModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        shoppingListModel.ProductName = Convert.ToString(rdr["ProductName"]);
                        shoppingListModel.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        shoppingListModel.CategoryName = Convert.ToString(rdr["CategoryName"]);
                        shoppingListModel.CostPrice = Convert.ToString(rdr["CostPrice"]);
                        shoppingListModel.QuantityToBuy = Convert.ToInt32(rdr["QuantityToBuy"]);
                        shoppingListModel.TotalValueOfLastPurchase = Convert.ToString(rdr["TotalValueOfLastPurchase"]);
                        listShoppingListModel.Add(shoppingListModel);
                    }
                }
                logger.Trace("GetAllShoppingList");
                return listShoppingListModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_ShoppingListGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<ShoppingListModel>> GetAllShoppingListAsync()
        {
            List<ShoppingListModel> listShoppingListModel = new List<ShoppingListModel>();
            List<ShoppingListModel> listShoppingListModelRet = new List<ShoppingListModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_ShoppingListGetAll", con))
                try
                {
                    logger.Trace("GetAllShoppingListAsync");
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ShoppingListModel shoppingListModel = new ShoppingListModel();
                        shoppingListModel.ProductId = Convert.ToInt32(rdr["ProductId"]);
                        shoppingListModel.ProductName = Convert.ToString(rdr["ProductName"]);
                        shoppingListModel.CategoryId = Convert.ToInt32(rdr["CategoryId"]);
                        shoppingListModel.CategoryName = Convert.ToString(rdr["CategoryName"]);
                        shoppingListModel.CostPrice = Convert.ToString(rdr["CostPrice"]);
                        shoppingListModel.QuantityToBuy = Convert.ToInt32(rdr["QuantityToBuy"]);
                        shoppingListModel.TotalValueOfLastPurchase = Convert.ToString(rdr["TotalValueOfLastPurchase"]);
                        listShoppingListModel.Add(shoppingListModel);
                    }

                    if(listShoppingListModel.Count > 0)
                    {
                        foreach (var shoppingListModel in listShoppingListModel)
                        {
                            if (shoppingListModel.QuantityToBuy > 0)
                            {
                                listShoppingListModelRet.Add(shoppingListModel);
                            }
                        }
                    }

                    return listShoppingListModelRet;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_ShoppingListGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        #endregion
    }
}
