using WebApi.Donne.Helpers;

namespace WebApi.Donne.Infrastructure
{
    public class BaseRepository
    {
        #region Properties
        public readonly IConfigurationRoot configurationRoot;
        public readonly string connectionString;
        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger logger;
        public string commandText { get; set; } = string.Empty;
        #endregion

        #region Constructor
        public BaseRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger _logger)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
            connectionString = configurationRoot.GetConnectionString("locaWebDonne");
            String keyString = "+BVZYjHomswT/+9NzdJR9G56qPGdaKk=";
            String encrypted = "ZrIa/8QJk1xOz2fUCwXBNQ==";
            String decrypted = StringEncryptor.Decrypt(encrypted, keyString);
            connectionString = connectionString + "Password=" + decrypted;
            logger = _logger;
        }
        #endregion
    }
}
