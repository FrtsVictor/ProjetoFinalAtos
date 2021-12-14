using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Exceptions;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using Np.Cryptography;

namespace DesafioAtos.Service.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _chaveParaCriptografia;
        private readonly ICriptografo _criptografo;

        public UsuarioService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICriptografo criptografo,
            string chaveParaCriptografia)
        {
            this._chaveParaCriptografia = chaveParaCriptografia;
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
                ValidarEntidade(usuarioParaAtualizar == null, "Falha ao encontrar usuario, verificar token");
                string senhaParaAtualizar = atualizarUsuarioDto.Senha;

                usuarioParaAtualizar.Login = atualizarUsuarioDto.Login ?? usuarioParaAtualizar.Login;

                usuarioParaAtualizar.Senha = string.IsNullOrEmpty(senhaParaAtualizar)
                    ? usuarioParaAtualizar.Senha
                    : _criptografo.Criptografar(_chaveParaCriptografia, senhaParaAtualizar);

                usuarioParaAtualizar.Nome = atualizarUsuarioDto.Nome ?? usuarioParaAtualizar.Nome;

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

        public async Task<ECategoria> AdicionarCategoria(CategoriaDto adicionarCategoriaDto)
        {
            var idCategoria = adicionarCategoriaDto.IdCategoria;
            var idUsuario = adicionarCategoriaDto.IdLigacao;
            ValidarCategoria(idCategoria);
            var categoriaExistente = await _unitOfWork.CategoriaUsuario.ObterCategoriaExistente(idCategoria, idUsuario);
            ValidarEntidade(categoriaExistente != null, "Categoria já cadastrada");

            var categoriaUsuario = new CategoriaUsuario() { IdCategoria = idCategoria, IdUsuario = idUsuario };

            return await _unitOfWork.ExecutarAsync(async () =>
            {
                await _unitOfWork.CategoriaUsuario.CriarAsync(categoriaUsuario);
                return (ECategoria)idCategoria;
            });
        }

        public async Task RemoverCategoria(CategoriaDto adicionarCategoriaDto)
        {
            var idCategoria = adicionarCategoriaDto.IdCategoria;
            var idUsuario = adicionarCategoriaDto.IdLigacao;
            ValidarCategoria(idCategoria);

            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var categoriaExistente = await _unitOfWork.CategoriaUsuario.ObterCategoriaExistente(idCategoria, idUsuario);
                
                if (categoriaExistente != null)
                {
                    await _unitOfWork.CategoriaUsuario.RemoverAsync(categoriaExistente.Id);
                }

                return categoriaExistente;
            });
        }

        public async Task<List<string>> ObterCategorias(int idUsuario)
        {
            return await _unitOfWork.CategoriaUsuario.ObterTodosNomeCategoriaPorUsuario(idUsuario);
        }

        private void ValidarCategoria(int value)
        {
            if (!Enum.IsDefined(typeof(ECategoria), value))
                throw new InvalidEnumException();
        }

        private void ValidarEntidade(bool isTrue, string mensagemErro)
        {
            if (isTrue)
            {
                throw new BadRequestException(mensagemErro);
            }
        }
    }
}
