using System.Collections.Concurrent;

namespace AspnetecorewebApi.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomLoggerProviderConfiguratiom loggerConfig;
        readonly 
    ConcurrentDictionary<string, CustomerLogger> Loggers= new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggerProvider(CustomLoggerProviderConfiguratiom config)
        {
            loggerConfig = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName">
        /// Criação do logger para uma categoria específica 
        /// 
        /// </param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            return Loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
        }

        /// <summary>
        /// liberando os recursos quando o método for descartado 
        /// </summary>
        public void Dispose()
        {
            Loggers.Clear();
        }






    }
}
