namespace WebApi.Donne.Infrastructure
{
    public class BaseRepository
    {
        #region Properties
        public IConfigurationRoot configurationRoot { get; set; }
        public string connectionString { get; set; }
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
