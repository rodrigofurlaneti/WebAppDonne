namespace WebApi.Donne.Infrastructure.SeedWork
{
    public class Logger : ILogger
    {
        public void TraceException(string message)
        {
            string log = message;
        }

        void ILogger.Trace(string message)
        {
            string log = message;
        }
    }
}
