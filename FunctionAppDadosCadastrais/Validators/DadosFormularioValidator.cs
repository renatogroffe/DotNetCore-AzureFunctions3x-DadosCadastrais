using System;
using FluentValidation;
using FunctionAppDadosCadastrais.Models;

namespace FunctionAppDadosCadastrais.Validators
{
    public class DadosFormularioValidator : AbstractValidator<DadosFormulario>
    {
        private readonly DateTime DATA_MIN = new DateTime(1899, 12, 31);
        private readonly DateTime DATA_MAX = new DateTime(2010, 1, 1);

        public DadosFormularioValidator()
        {
            RuleFor(d => d.Email).NotEmpty().WithMessage("Preencha o campo 'Email'")
                .MinimumLength(10).WithMessage("O campo 'Email' deve possuir no mínimo 10 caracteres")
                .MaximumLength(100).WithMessage("O campo 'Email' deve possuir no máximo 100 caracteres")
                .EmailAddress().WithMessage("Valor inválido para o campo 'Email'");

            RuleFor(d => d.Nome).NotEmpty().WithMessage("Preencha o campo 'Nome'")
                .MinimumLength(5).WithMessage("O campo 'Nome' deve possuir no mínimo 5 caracteres")
                .MaximumLength(70).WithMessage("O campo 'Nome' deve possuir no máximo 70 caracteres");

            RuleFor(d => d.DataNascimento).NotEmpty().WithMessage("Preencha o campo 'DataNascimento'")
                .GreaterThan(DATA_MIN).WithMessage("Valor inválido para o campo 'DataNascimento'")
                .LessThanOrEqualTo(DATA_MAX).WithMessage("Valor inválido para o campo 'DataNascimento'");

            RuleFor(d => d.CodEstado).NotEmpty().WithMessage("Preencha o campo 'CodEstado'")
                .Length(2).WithMessage("O campo 'CodEstado' deve possuir 2 caracteres");

            RuleFor(d => d.Formacao).NotEmpty().WithMessage("Preencha o campo 'Formacao'")
                .MaximumLength(50).WithMessage("O campo 'Formacao' deve possuir no máximo 50 caracteres");

            RuleFor(d => d.AreaAtuacao).NotEmpty().WithMessage("Preencha o campo 'AreaAtuacao'")
                .MaximumLength(50).WithMessage("O campo 'AreaAtuacao' deve possuir no máximo 50 caracteres");

            RuleFor(d => d.FlCertificacao).NotEmpty().WithMessage("Preencha o campo 'FlCertificacao'");

            RuleFor(d => d.Salario).NotEmpty().WithMessage("Preencha o campo 'Salario'")
                .GreaterThanOrEqualTo(0).WithMessage("O campo 'Salario' deve ser maior ou a zero'")
                .LessThanOrEqualTo(99_999.99).WithMessage("Valor inválido para o campo 'Salario'");
        }
    }
}