using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class AtualizarUsuarioDtoValidacao : AbstractValidator<AtualizarUsuarioDto>
    {
        public AtualizarUsuarioDtoValidacao()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("Login necessário");

            RuleFor(x => x.Senha)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Nome")
               .MinimumLength(6).WithMessage("Senha muito pequena")
               .MaximumLength(50).WithMessage("Senha muito grande");
        }
    }
}
