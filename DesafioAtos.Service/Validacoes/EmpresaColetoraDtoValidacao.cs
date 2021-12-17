﻿using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class EmpresaColetoraDtoValidacao : AbstractValidator<EmpresaColetoraDto>
    {
        public EmpresaColetoraDtoValidacao()
        {
            // RuleFor(x => x.)
            //     .NotEmpty()
            //     .NotNull()
            //     .WithMessage("Necessário Informar a Categoria")
            //     .MinimumLength(14).WithMessage("CNPJ inválido")
            //     .MaximumLength(14).WithMessage("CNPJ inválido");

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Necessário informar telefone")
                .MinimumLength(8).WithMessage("Telefone Inválido")
                .MaximumLength(14).WithMessage("Telefone Inválido");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Email não pode ser nulo")
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("Necessário Informar o Nome");

           
        }
    }
}
