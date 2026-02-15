namespace AspnetecorewebApi.Logging
{

    /// <summary>
    /// LogLevel: Define o nível mínimo de log a ser registrado, com o padrão 
    /// EventId: Define o ID do evento de log, com o padrão sendo zero 
    /// 
    /// </summary>
    public class CustomLoggerProviderConfiguratiom
    {
    // é utilizada para definir o nível mínmo de log a ser registrado, com o padrão sendo LogLevel.Information.
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public int EventId { get; set; } = 0;

    }
}
