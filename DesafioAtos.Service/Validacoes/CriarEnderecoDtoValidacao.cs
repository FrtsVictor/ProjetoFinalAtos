using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class CriarEnderecoDtoValidacao : AbstractValidator<CriarEnderecoDto>
    {
        public CriarEnderecoDtoValidacao()
        {
            RuleFor(x => x.Cidade)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar a cidade")
               .MinimumLength(6).WithMessage("Nome da cidade é muito pequeno")
               .MaximumLength(100).WithMessage("Nome da cidade é muito grande"); ;

            RuleFor(x => x.Cep)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Nome")
               .MinimumLength(8).WithMessage("CEP inválido")
               .MaximumLength(8).WithMessage("CEP inválido");

            RuleFor(x => x.Numero)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Número da empresa")
               .MaximumLength(10).WithMessage("Número Inválido");

            RuleFor(x => x.Complemento)
               .MaximumLength(100).WithMessage("Complemeto muito grande");

            RuleFor(x => x.Estado)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o estado")
               .MinimumLength(3).WithMessage("Nome do estado é muito pequeno")
               .MaximumLength(100).WithMessage("Nome do estado é muito grande");

            RuleFor(x => x.Rua)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o nome da rua")
               .MinimumLength(3).WithMessage("Nome da rua é muito pequeno")
               .MaximumLength(100).WithMessage("Nome da rua é muito grande");

        }
    }
}
