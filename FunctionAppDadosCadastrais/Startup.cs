using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using FunctionAppDadosCadastrais.Mappings;
using FunctionAppDadosCadastrais.Data;
using FunctionAppDadosCadastrais.Business;

[assembly: FunctionsStartup(typeof(FunctionAppDadosCadastrais.Startup))]
namespace FunctionAppDadosCadastrais
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddScoped<CadastroRepository>();
            builder.Services.AddScoped<CadastroServices>();
        }
    }
}