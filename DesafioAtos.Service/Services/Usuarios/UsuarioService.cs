using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Domain.Enums;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using DesafioAtos.Service.Validacoes;
using Np.Cryptography;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Service.Services;

namespace DesafioAtos.Service.Usuarios
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<Usuario> CriarConta(CriarUsuarioDto criarUsuarioDto)
        {
            var usuarioParaCriacao = _mapper.MapCriarUsuarioDtoToUsuario(criarUsuarioDto);
            return await _unitOfWork.ExecutarAsync(async () =>
                 await _unitOfWork.Users.CriarAsync(usuarioParaCriacao));
        }

        public async Task Editar(int idUsusario, EditarUsuarioDto editarUsuarioDto)
        {
            var usuarioParaAtualizar = await _unitOfWork.Users.ObterPorIdAsync(idUsusario);
            ValidarEntidade(usuarioParaAtualizar == null, "Falha ao encontrar usuario, verificar token");
            _mapper.MapEditarUsuarioDtoToUsuario(editarUsuarioDto, usuarioParaAtualizar);
            _unitOfWork.Executar(() => _unitOfWork.Users.Atualizar(usuarioParaAtualizar));
        }

        public async Task Remover(int id) => await _unitOfWork.VoidExecutarAsync(
            async () => await _unitOfWork.Users.RemoverAsync(id));

        public async Task<ECategoria> AdicionarCategoria(CategoriaDto adicionarCategoriaDto)
        {
            var idCategoria = adicionarCategoriaDto.IdCategoria;
            var idUsuario = adicionarCategoriaDto.IdLigacao;
            ValidarCategoria(idCategoria);
            var categoriaExistente = await _unitOfWork.CategoriaUsuario.ObterCategoriaPorId(idCategoria, idUsuario);
            ValidarEntidade(categoriaExistente != null, "Categoria já cadastrada");
            var categoriaUsuario = _mapper.CriarCategoriaUsuario(idUsuario, idCategoria);

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
                var categoriaExistente = await _unitOfWork.CategoriaUsuario.ObterCategoriaPorId(idCategoria, idUsuario);

                if (categoriaExistente != null)
                {
                    await _unitOfWork.CategoriaUsuario.RemoverAsync(categoriaExistente.Id);
                }
            });
        }

        public async Task<IEnumerable<string>?> ObterCategorias(int idUsuario)
        {
            var categorias = await _unitOfWork.CategoriaUsuario.ObterTodasCategoriasPorUsuario(idUsuario);
            return categorias?.Select(x => x.Nome);
        }


        public async Task<IEnumerable<EmpresaColetoraDto>?> ObterEmpresasPorCategoriaUsuario(int idUsuario) => await _unitOfWork
            .ExecutarAsync(async () =>
            {
                var categorias = await _unitOfWork.CategoriaUsuario.ObterTodasCategoriasPorUsuario(idUsuario);
                var ids = categorias?.Select(x => x.Id);
                var empresas = await _unitOfWork.CategoriaEmpresa.ObterEmpresasPorIdCategoria(ids);
                empresas = empresas?.DistinctBy(x => x.IdEmpresaColetora);
                return empresas?.Select(x => _mapper.MapEmpresaColetoraToEmpresaColetoraDto(x.EmpresaColetora));
            });
    }
}
