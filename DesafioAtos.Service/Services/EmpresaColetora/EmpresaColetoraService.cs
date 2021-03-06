using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Entidades;
using DesafioAtos.Infra.UnitWork;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Domain.Enums;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public class EmpresaColetoraService : BaseService, IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const string FALHA_EMPRESA = "Falha ao encontrar Empresa, verificar Token";
        private const string CATEGORIA_CADASTRADA = "Categoria já cadastrada";

        public EmpresaColetoraService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<string>?> ObterCategorias(int id)
        {
            var categorias = await _unitOfWork.ExecutarAsync(
                async () => await _unitOfWork.CategoriaEmpresa.ObterTodasCategoriasPorEmpresa(id));

            return categorias?.Select(x => x.Nome);
        }

        public async Task<IEnumerable<EnderecoDto?>> ObterEnderecos(int idEmpresa)
        {
            var enderecos = await _unitOfWork.ExecutarAsync(
                async () => await _unitOfWork.Endereco.ObterTodosPorIdEmpresaAsync(idEmpresa));
            return enderecos?.Select(_mapper.MapEnderecoToEnderecoDto);
        }

        public async Task EditarEndereco(int idEndereco, EditarEnderecoDto editarEndereco)
        {
            var endereco = await _unitOfWork.Endereco.ObterPorIdAsync(idEndereco);
            ValidarEntidade(endereco == null, "ENDERECO_INVALIDO");
            _mapper.MapEditarEnderecoToEndereco(editarEndereco, endereco);
            _unitOfWork.Executar(() => _unitOfWork.Endereco.Atualizar(endereco));
        }

        public async Task RemoverEndereco(int idEndereco)
        {
            await _unitOfWork.VoidExecutarAsync(async () => await _unitOfWork.Endereco.RemoverAsync(idEndereco));
        }

        public async Task<ObterEmpresaDto> ObterEmpresaColetora(int idEmpresaColetora)
        {
            var empresaColetora = await _unitOfWork.EmpresaColetora.ObterPorIdAsync(idEmpresaColetora);
            return _mapper.MapEmpresaToObterEmpresaDto(empresaColetora);
        }

        public async Task<int> CriarEmpresaColetora(CriarEmpresaColetoraDto empresaColetoraDto)
        {
            empresaColetoraDto.Categorias.ForEach(ValidarCategoria);
            var empresaColetora = _mapper.MapCriarEmpresaDtoToEmpresaColetora(empresaColetoraDto);

            await _unitOfWork.ExecutarTransacaoAsync(
                async () => await _unitOfWork.EmpresaColetora.CriarAsync(empresaColetora),
                async () =>
                {
                    var categorias = empresaColetoraDto.Categorias.Select(x =>
                        new CategoriaEmpresa()
                        {
                            IdCategoria = x,
                            IdEmpresaColetora = empresaColetora.Id
                        });
                    await _unitOfWork.CategoriaEmpresa.CriarVariosAsync(categorias);
                }
            );

            return empresaColetora.Id;
        }

       
        public async Task EditarEmpresaColetora(int idEmpresaColetora, EditarEmpresaColetoraDto editarEmpresaDto)
        {
            var empresaColetora = await _unitOfWork.ExecutarAsync(
                async () => await _unitOfWork.EmpresaColetora.ObterPorIdAsync(idEmpresaColetora));
            ValidarEntidade(empresaColetora == null, FALHA_EMPRESA);
            _mapper.MapEditarEmpresaDtoToEmpresaColetora(editarEmpresaDto, empresaColetora);
            _unitOfWork.Executar(() => _unitOfWork.EmpresaColetora.Atualizar(empresaColetora));
        }

        public async Task DeletarEmpresaColetora(int id) =>
            await _unitOfWork.EmpresaColetora.RemoverAsync(id);

        public async Task<int> AdicionarEndereco(CriarEnderecoDto enderecoDto, int idEmpresa)
        {
            var endereco = _mapper.MapCriarEnderecoDtoToEndereco(enderecoDto);
            endereco.IdEmpresaColeta = idEmpresa;
            await _unitOfWork.VoidExecutarAsync(async () => await _unitOfWork.Endereco.CriarAsync(endereco));
            return endereco.Id;
        }

        public async Task<ECategoria> AdicionarCategoria(CategoriaDto adicionarCategoriaDto)
        {
            var idCategoria = adicionarCategoriaDto.IdCategoria;
            ValidarCategoria(idCategoria);
            var idEmpresa = adicionarCategoriaDto.IdLigacao;
            var categoriaExistente = await _unitOfWork.CategoriaEmpresa.ObterCategoriaPorId(idCategoria, idEmpresa);
            ValidarEntidade(categoriaExistente != null, CATEGORIA_CADASTRADA);
            var categoriaEmpresa = _mapper.CriarCategoriaEmpresa(idEmpresa, idCategoria);

            return await _unitOfWork.ExecutarAsync(async () =>
            {
                await _unitOfWork.CategoriaEmpresa.CriarAsync(categoriaEmpresa);
                return (ECategoria) idCategoria;
            });
        }

        public async Task RemoverCategoria(CategoriaDto categoriaDto)
        {
            var idCategoria = categoriaDto.IdCategoria;
            ValidarCategoria(idCategoria);
            var idEmpresa = categoriaDto.IdLigacao;

            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var categoriaExistente = await _unitOfWork.CategoriaEmpresa.ObterCategoriaPorId(idCategoria, idEmpresa);

                if (categoriaExistente != null)
                {
                    await _unitOfWork.CategoriaEmpresa.RemoverAsync(categoriaExistente.Id);
                }
            });
        }
    }
}