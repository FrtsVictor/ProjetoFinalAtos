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
<<<<<<< HEAD
                throw new InvalidEnumException("Id categoria invalido.");
=======
                throw new InvalidEnumException();
>>>>>>> a4c0c85 (datanotation)
        }

        public void ValidarEntidade(bool isTrue, string mensagemErro)
        {
            if (isTrue)
<<<<<<< HEAD
                throw new BadRequestException(mensagemErro);
=======
            {
                throw new BadRequestException(mensagemErro);
            }
>>>>>>> a4c0c85 (datanotation)
        }
    }
}