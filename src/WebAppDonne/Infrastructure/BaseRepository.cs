namespace WebApi.Donne.Infrastructure
{
    public class BaseRepository
    {
        #region Properties
        public readonly IConfigurationRoot configurationRoot;
        public readonly string connectionString;
        public readonly WebApi.Donne.Infrastructure.SeedWork.ILogger logger;
        #endregion

        #region Constructor
        public BaseRepository(WebApi.Donne.Infrastructure.SeedWork.ILogger _logger)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
            connectionString = configurationRoot.GetConnectionString("locaWebDonne");
            logger = _logger;
        }
        #endregion
    }
}
