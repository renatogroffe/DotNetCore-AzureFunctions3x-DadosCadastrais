using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FunctionAppDadosCadastrais.Business;

namespace FunctionAppDadosCadastrais
{
    public class ListarDadosCadastrais
    {
        private readonly CadastroServices _cadastroSvc;

        public ListarDadosCadastrais(CadastroServices cadastroSvc)
        {
            _cadastroSvc = cadastroSvc;
        }

        [FunctionName("ListarDadosCadastrais")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Function ListarDadosCadastrais - HTTP GET");
            return new OkObjectResult(new
            {
                Versao = "v2",
                Dados = _cadastroSvc.ListAll()
            });
        }
    }
}
