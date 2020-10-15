using AutoMapper;
using FunctionAppDadosCadastrais.Models;

namespace FunctionAppDadosCadastrais.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DadosFormulario, CadastroPessoa>();
        }
    }
}