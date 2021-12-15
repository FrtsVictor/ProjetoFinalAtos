using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public class EmpresaColetoraService : BaseService, IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork = null!;
        private readonly IMapper _mapper = null!;

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

        public async Task<IEnumerable<EnderecoDto?>> ObterEnderecos (int idEmpresa)
        {
            var enderecos = await _unitOfWork.ExecutarAsync(async () => await _unitOfWork.Endereco.ObterTodosPorIdEmpresaAsync(idEmpresa));
            return enderecos?.Select(_mapper.MapEnderecoToEnderecoDto);
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

        public async Task EditarEditarEmpresaColetora(int idEmpresaColetora, EditarEmpresaColetoraDto editarEmpresaDto)
        {
            var empresaColetora = await _unitOfWork.ExecutarAsync(
                async () => await _unitOfWork.EmpresaColetora.ObterPorIdAsync(idEmpresaColetora));
            ValidarEntidade(empresaColetora == null, "Falha ao encontrar Empresa, verificar Token");
            _mapper.MapEditarEmpresaDtoToEmpresaColetora(editarEmpresaDto, empresaColetora);
            _unitOfWork.Executar(() => _unitOfWork.EmpresaColetora.Atualizar(empresaColetora));
        }

        public async Task DeletaEmpresaColetora(int id) =>
            await _unitOfWork.EmpresaColetora.RemoverAsync(id);

        public async Task<int> AdicionarEndereco(CriarEnderecoDto enderecoDto, int idEmpresa)
        {
            var endereco = _mapper.MapCriarEnderecoDtoToEndereco(enderecoDto);
            endereco.IdEmpresaColeta = idEmpresa;
            await _unitOfWork.VoidExecutarAsync(async () => await _unitOfWork.Endereco.CriarAsync(endereco));
            return endereco.Id;
        }
    }
}