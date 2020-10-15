using System;

namespace FunctionAppDadosCadastrais.Models
{
    public class DadosFormulario
    {
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value?.Trim().ToLower();
        }        

        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CodEstado { get; set; }
        public string Formacao { get; set; }
        public string AreaAtuacao { get; set; }
        public bool? FlCertificacao { get; set; }
        public double? Salario { get; set; }                
    }
}