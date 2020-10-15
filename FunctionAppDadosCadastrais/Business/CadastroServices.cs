using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using AutoMapper;
using FunctionAppDadosCadastrais.Data;
using FunctionAppDadosCadastrais.Models;
using FunctionAppDadosCadastrais.Validators;

namespace FunctionAppDadosCadastrais.Business
{
    public class CadastroServices
    {
        private readonly IMapper _mapper;
        private readonly CadastroRepository _repository;

        public CadastroServices(IMapper mapper,
            CadastroRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IActionResult Get()
        {
            return new OkObjectResult(
                _mapper.Map<List<CadastroPessoa>>(_repository.ListAll()));
        }

        public IActionResult Save(string strDadosFormulario)
        {
            var dadosFormulario = DeserializeDadosFormulario(strDadosFormulario);
            var resultado = DadosValidos(dadosFormulario);
            resultado.Acao = "Inclusão de Dados Cadastrais";
        
            if (resultado.Inconsistencias.Count == 0)
            {
                CadastroPessoa cadastro = _repository.GetByEmail(
                    dadosFormulario.Email);
                if (cadastro == null)
                    cadastro = _mapper.Map<CadastroPessoa>(dadosFormulario);
                else
                    cadastro = _mapper.Map<DadosFormulario, CadastroPessoa>(dadosFormulario, cadastro);
                
                _repository.Save(cadastro);
                return new OkObjectResult(resultado);
            }
            else
                return new BadRequestObjectResult(resultado);
        }

        public IActionResult ListAll()
        {
            return new OkObjectResult(_repository.ListAll());
        }

        private DadosFormulario DeserializeDadosFormulario(string dados)
        {
            DadosFormulario dadosFormulario;
            try
            {
                dadosFormulario = JsonSerializer.Deserialize<DadosFormulario>(dados,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
            catch
            {
                dadosFormulario = null;
            }

            return dadosFormulario;
        }

        private Resultado DadosValidos(DadosFormulario dadosFormulario)
        {
            var resultado = new Resultado();
            if (dadosFormulario == null)
            {
                resultado.Inconsistencias.Add(
                    "Preencha os Dados Cadastrais");
            }
            else
            {
                var validator = new DadosFormularioValidator().Validate(dadosFormulario);
                if (!validator.IsValid)
                {
                    foreach (var errors in validator.Errors)
                        resultado.Inconsistencias.Add(errors.ErrorMessage);
                }
            }

            return resultado;
        }
    }
}