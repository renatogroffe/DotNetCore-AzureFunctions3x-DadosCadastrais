using System;
using Dapper.Contrib.Extensions;

namespace FunctionAppDadosCadastrais.Models
{
    [Table("dbo.DadosCadastrais")]
    public class CadastroPessoa
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAlteracao { get; set; }
        public string CodEstado { get; set; }
        public string Formacao { get; set; }
        public string AreaAtuacao { get; set; }
        public bool FlCertificacao { get; set; }
        public double Salario { get; set; }
    }
}