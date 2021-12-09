using DesafioAtos.Domain.Dtos.Usuario;
using DesafioAtos.Infra.UnitOfWorks;

namespace DesafioAtos.Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var user = await _unitOfWork.Users.ObterPorIdAsync(1);
                _unitOfWork.Users.Atualizar(user);
                return user;
            });
        }

        public async Task Remover(long id)
        {
            await _unitOfWork.ExecutarAsync(async () =>
           {
               await _unitOfWork.Users.RemoverAsync(id);
               return id;
           });
        }
    }
}
