using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
///<summary>
/// tratamento de Exceções Repetitivo
/// Há repetição de código  para tratamento de exceção em cada 
/// método do controlador. Isso aumenta a duplicação de código 
/// e dificulta a manutenção.
/// 
/// Solução 
/// para melhorar o tratamento de execeções podemos seguir as boas práticas utilizando um middleware de 
/// execução podems seguir as boas práticas utilizando um middleware de execução glbal e craindo um filtro de ação 
/// 
/// </summary>
namespace AspnetecorewebApi.filter
{
    public class ApiExceptionFilter : IExceptionFilter 
    {
        private readonly ILogger<ApiExceptionFilter>
            _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu un erro exceção não tratada");
            context.Result = new ObjectResult("Ocorreu um probrlema a pôs tratar sua solicitação")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
