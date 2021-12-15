using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Exceptions;
using DesafioAtos.Service.Exceptions;

namespace DesafioAtos.Service.Services
{
    public class BaseService : IBaseService
    {
        public void ValidarCategoria(int value)
        {
            if (!Enum.IsDefined(typeof(ECategoria), value))
                throw new InvalidEnumException();
        }

        public void ValidarEntidade(bool isTrue, string mensagemErro)
        {
            if (isTrue)
            {
                throw new BadRequestException(mensagemErro);
            }
        }
    }
}