using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class CriarUsuarioDtoValidacao : AbstractValidator<CriarUsuarioDto>
    {
        public CriarUsuarioDtoValidacao()
        {
            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage("Login necessário");
        }
    }
}
