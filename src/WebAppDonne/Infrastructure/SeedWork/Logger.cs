namespace WebApi.Donne.Infrastructure.SeedWork
{
    public class Logger : ILogger
    {
        public string log { get; set; }
        public void TraceException(string message)
        {
            this.log = message;
        }

        void ILogger.Trace(string message)
        {
            this.log = message;
        }
    }
}
