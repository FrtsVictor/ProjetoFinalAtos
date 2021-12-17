using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class ColetaDtoValidacao : AbstractValidator<ColetaDto>
    {
        public ColetaDtoValidacao()
        {
            RuleFor(x => x.ItemDeColeta)
                .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Item de Coleta");

            RuleFor(x => x.Nome)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Nome")
               .MinimumLength(6).WithMessage("Nome muito pequeno")
               .MaximumLength(200).WithMessage("Nome muito grande");

            RuleFor(x => x.Categoria)
               .NotEmpty()
               .NotNull()
               .IsInEnum();

        }
    }
}
