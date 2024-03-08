using Domain.Donne;
using Business.Donne;
using System.Data.SqlClient;
using System.Data;

namespace WebApi.Donne.Infrastructure.ShoppingList
{
    public class ShoppingListRepository : BaseRepository, IShoppingListRepository
    {
        #region Constructor

        public ShoppingListRepository(SeedWork.ILogger logger) : base(logger) { }

        #endregion

        #region Methods 

        public IEnumerable<ShoppingListModel> GetAll()
        {
            try
            {
                logger.Trace("ShoppingList_GetAll_Entry");
                commandText = "USP_ShoppingListGetAll";
                List<ShoppingListModel> listShoppingListModel = new List<ShoppingListModel>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GetListShoppingModel(sqlDataReader, listShoppingListModel);
                    }
                }
                logger.Trace("ShoppingList_GetAll_Exit");
                return listShoppingListModel;
            }
            catch (ArgumentNullException ex)
            {
                logger.TraceException("ShoppingList_GetAll");
                string mensagemErro = "Erro ao consumir a procedure USP_ShoppingListGetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<ShoppingListModel>> GetAllAsync()
        {
                try
                {
                    logger.Trace("ShoppingList_GetAllAsync_Entry");
                    commandText = "USP_ShoppingListGetAll";
                    List<ShoppingListModel> listShoppingListModel = new List<ShoppingListModel>();
                    List<ShoppingListModel> listShoppingListModelRet = new List<ShoppingListModel>();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                        while (sqlDataReader.Read())
                        {
                            GetListShoppingModel(sqlDataReader, listShoppingListModel);
                        }

                        if (listShoppingListModel.Count > 0)
                        {
                            listShoppingListModelRet = ShoppingListBusiness.ShoppingListBusinessValid(listShoppingListModel);
                        }
                    }
                    logger.Trace("ShoppingList_GetAllAsync_Exit");
                    return listShoppingListModelRet;
                }
                catch (ArgumentNullException ex)
                {
                    logger.TraceException("ShoppingList_GetAllAsync");
                    string mensagemErro = "Erro ao consumir a procedure USP_ShoppingListGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        #endregion

        #region Helpers
        private static void GetListShoppingModel(SqlDataReader sqlDataReader, List<ShoppingListModel> listShoppingListModel)
        {
            ShoppingListModel shoppingListModel = new ShoppingListModel();
            GetShoppingListModel(sqlDataReader, shoppingListModel);
            listShoppingListModel.Add(shoppingListModel);
        }

        private static void GetShoppingListModel(SqlDataReader sqlDataReader, ShoppingListModel shoppingListModel)
        {
            shoppingListModel.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
            shoppingListModel.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
            shoppingListModel.CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]);
            shoppingListModel.CategoryName = Convert.ToString(sqlDataReader["CategoryName"]);
            shoppingListModel.CostPrice = Convert.ToString(sqlDataReader["CostPrice"]);
            shoppingListModel.QuantityToBuy = Convert.ToInt32(sqlDataReader["QuantityToBuy"]);
            shoppingListModel.TotalValueOfLastPurchase = Convert.ToString(sqlDataReader["TotalValueOfLastPurchase"]);
        }

        #endregion

    }
}
