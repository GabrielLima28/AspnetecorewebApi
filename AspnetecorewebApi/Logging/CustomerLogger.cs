
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace AspnetecorewebApi.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguratiom loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguratiom config)
        {
            loggerName = name;
            loggerConfig = config;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logLevel"> ele passa 
        /// o nível de log a ser verificado, e o método retorna true se o
        /// nivel de log for igual ao nível configurado.
        /// 
        /// </param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {

            return logLevel == loggerConfig.LogLevel;
        }
        public IDisposable BeginScope<Tstate>( ThreadState state)
        {
            return null;
        }

        public void Log<TSTate>(LogLevel logLevel, EventId eventId, TSTate state, Exception exception, Func<TSTate, Exception, string> formatte)
        {
            string mensagempassada = $"{logLevel.ToString()}: {eventId.Id} -{
                formatte
                (state, exception)}";

            EscreverTextoNoArquivo(mensagempassada);
        }
        private void EscreverTextoNoArquivo(string mensagem)
        {
            string pastaLog = @"C:\Users\gabri\Downloads\logges";
            Directory.CreateDirectory(pastaLog);

            string arquivoLog = Path.Combine(pastaLog, "app.log");

            // Remova try/catch que só relança e não adiciona contexto
            using (var streamwriter = new StreamWriter(arquivoLog, append: true))
            {
                streamwriter.WriteLine(mensagem);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"> Definição de registro da informação do Log 
        /// 
        /// </param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return NoopScope.Instance;
        }
    }
    }

