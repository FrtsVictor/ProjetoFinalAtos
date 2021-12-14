using DesafioAtos.Domain.Dtos;
using FluentValidation;

namespace DesafioAtos.Service.Validacoes
{
    public class LogarUsuarioDtoValidacao : AbstractValidator<LogarUsuarioDto>
    {
        public LogarUsuarioDtoValidacao()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Item de Coleta");

            RuleFor(x => x.Senha)
               .NotEmpty()
               .NotNull()
               .WithMessage("Necessário Informar o Nome")       
               .MinimumLength(6).WithMessage("Senha muito pequena")
               .MaximumLength(50).WithMessage("Senha muito grande");
        }
    }
}
