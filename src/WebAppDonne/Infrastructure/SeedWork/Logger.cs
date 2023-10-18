namespace WebApi.Donne.Infrastructure.SeedWork
{
    public class Logger
    {
        private readonly ILogger _logger;
        public Logger(ILogger logger)
        {
            this._logger = logger;
        }

        public bool Trace(string mensagem)
        {
            if(mensagem == string.Empty)
                return false;
            else
                return true;
        }
    }
}
