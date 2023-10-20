namespace WebApi.Donne.Infrastructure.SeedWork
{
    public class Logger : ILogger
    {
        public void TraceExeption(string message)
        {
            string log = message;
        }

        void ILogger.Trace(string message)
        {
            string log = message;
        }
    }
}
