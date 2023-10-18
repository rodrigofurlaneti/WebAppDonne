namespace WebApi.Donne.Infrastructure
{
    public class BaseRepository
    {
        #region Properties
        public readonly IConfigurationRoot configurationRoot;
        public readonly string connectionString;
        #endregion

        #region Constructor
        public BaseRepository()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            configurationRoot = configurationBuilder.Build();
            connectionString = configurationRoot.GetConnectionString("locaWebDonne");
        }
        #endregion
    }
}
