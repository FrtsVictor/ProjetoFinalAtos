using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _chaveParaCriptografia;
        private readonly ICriptografo _criptografo;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, ICriptografo criptografo)
        {
            this._chaveParaCriptografia = configuration["cryptography:AppPasswordKey"];
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
        }

        public async Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarioParaCriacao = _mapper.MapCriarUsuarioDtoToUsuario(criarUsuarioDto);
            var senhaCriptografada = _criptografo.Criptografar(_chaveParaCriptografia, usuarioParaCriacao.Senha);
            usuarioParaCriacao.Senha = senhaCriptografada;

            return await _unitOfWork.ExecutarAsync(async () =>
            {
                return await _unitOfWork.Users.CriarAsync(usuarioParaCriacao);
            });
        }

        public async Task Atualizar(AtualizarUsuarioDto atualizarUsuarioDto)
        {
            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var usuarioParaAtualizar = await _unitOfWork.Users.ObterPorIdAsync(atualizarUsuarioDto.Id);
                ValidarUsuario(usuarioParaAtualizar);

                usuarioParaAtualizar.Login = atualizarUsuarioDto.Login;
                string senhaCriptografada = _criptografo.Criptografar(_chaveParaCriptografia, atualizarUsuarioDto.Senha);
                usuarioParaAtualizar.Senha = senhaCriptografada;
                usuarioParaAtualizar.Nome = atualizarUsuarioDto.Nome;

                _unitOfWork.Users.Atualizar(usuarioParaAtualizar);
                return usuarioParaAtualizar;
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

        private void ValidarUsuario(Usuario usuario)
        {   
            if(usuario == null)
            {
                throw new BadRequestException();
            }
        }
    }
}
