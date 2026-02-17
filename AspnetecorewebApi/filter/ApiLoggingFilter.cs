using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;
// classe que vai executar um filtro 
// de ação 
namespace AspnetecorewebApi.filter
{
    public class ApiLoggingFilter : IActionFilter

    {
        // seria uma classe de log para registrar as informações da requisição e resposta da APi 
        /// <summary>
        /// classe de log para registrar as informações da requisição e resposta da API 
        /// resumindo o processo de execução da ação, o filtro de ação é executado antes e depois da 
        /// execução da ação do controlador, permitindo que você registre informações relevantes sobre 
        /// a requisição, como o tempo de execução, os parâmetros de entrada e a resposta gerada.
        /// 
        /// </summary>

        private readonly ILogger<ApiLoggingFilter> logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // execute antwes da actions
            // ele loga loga as informações da requisição 
            logger.LogInformation("####Executando -> OnActionExecuting");
            logger.LogInformation("######################################");
            logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            logger.LogInformation("######################################");



        }
        public void OnActionExecuted(ActionExecutingContext context)
        {

            logger.LogInformation("####Executando -> OnActionExecuted");
            logger.LogInformation("######################################");
            logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
            logger.LogInformation($"ModelState: {context.ModelState.IsValid}");
            logger.LogInformation("######################################");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
