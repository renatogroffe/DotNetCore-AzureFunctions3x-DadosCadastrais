using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;
using FunctionAppDadosCadastrais.Models;

namespace FunctionAppDadosCadastrais.Data
{
    public class CadastroRepository
    {
        public CadastroPessoa GetByEmail(string email)
        {
            using var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseDadosCadastrais"));

            return conexao.QueryFirstOrDefault<CadastroPessoa>(
                "SELECT * FROM dbo.DadosCadastrais " +
                "WHERE Email = @Email", new { Email = email });
        }

        public void Save(CadastroPessoa pessoa)
        {
            using var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseDadosCadastrais"));

            if (pessoa.Id == 0)
            {
                pessoa.DtInclusao = DateTime.Now;
                conexao.Insert(pessoa);
            }
            else
            {
                pessoa.DtAlteracao = DateTime.Now;
                conexao.Update(pessoa);
            }
        }

        public List<CadastroPessoa> ListAll()
        {
            using var conexao = new SqlConnection(
                Environment.GetEnvironmentVariable("BaseDadosCadastraisConsulta"));

            return conexao.GetAll<CadastroPessoa>().ToList();
        }
    }
}