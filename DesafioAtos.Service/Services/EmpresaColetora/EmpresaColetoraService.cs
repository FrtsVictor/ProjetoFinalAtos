
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Validacoes;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;
using DesafioAtos.Domain.Entidades;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public class EmpresaColetoraService : IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _chaveParaCriptografia;
        private readonly ICriptografo _criptografo;

        public EmpresaColetoraService(
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

        public async Task<DesafioAtos.Domain.Entidades.EmpresaColetora> CriarEmpresaColetora(CriarEmpresaColetoraDto criarEmpresaColetoraDto)
        {
            var resultadoValidacao = new CriarEmpresaColetoraDtoValidacao().Validate(criarEmpresaColetoraDto);
            if (!resultadoValidacao.IsValid)
                throw new InvalidOperationException(string.Join("\n", resultadoValidacao.Errors.Select(s => s)));


            var empresaColetora = _mapper.MapEmpresaColetoraDtoToEmpresaColetora(criarEmpresaColetoraDto);
            var verificarCnpj = ValidaCnpj.IsCnpj(empresaColetora.Cnpj);
            var verificaEmail = RegexUtilities.ValidaEmail(empresaColetora.Email);


            return await _unitOfWork.ExecutarAsync(async () =>
             await _unitOfWork.EmpresaColetoraRepository.CriarAsync(empresaColetora));

        }

        public async Task AtualizarEmpresaColetora(EditarEmpresaColetoraDto atualizarEmpresaColetoraDto)
        {
            var resultadoEmpresa = new EditarEmpresaColetoraDtoValidacao().Validate(atualizarEmpresaColetoraDto);
            if (resultadoEmpresa != null)

                throw new InvalidOperationException(string.Join("\n", resultadoEmpresa.Errors.Select(s => s)));

            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var empresaColetoraParaAtualizar = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(atualizarEmpresaColetoraDto.Id);
                string senhaParaAtualizar = atualizarEmpresaColetoraDto.Senha;
                empresaColetoraParaAtualizar.Cnpj = atualizarEmpresaColetoraDto.Cnpj;

                empresaColetoraParaAtualizar.Senha = string.IsNullOrEmpty(senhaParaAtualizar)
                    ? empresaColetoraParaAtualizar.Senha
                    : _criptografo.Criptografar(_chaveParaCriptografia, senhaParaAtualizar);

                empresaColetoraParaAtualizar.Telefone = atualizarEmpresaColetoraDto.Telefone;

                empresaColetoraParaAtualizar.Nome = atualizarEmpresaColetoraDto.Nome;
                empresaColetoraParaAtualizar.Email = atualizarEmpresaColetoraDto.Email;
                empresaColetoraParaAtualizar.Telefone = atualizarEmpresaColetoraDto.Telefone;

            });

        }

        public async Task Remover(long id)
        {
            await _unitOfWork.ExecutarAsync(async () =>
            {
                await _unitOfWork.EmpresaColetoraRepository.RemoverAsync(id);
                return id;
            });
        }

        public async Task<IEnumerable<string>> ObterEmpresaColetaPorId(long idEmpresa)
        {
            var empresa = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(idEmpresa);
            return empresa;
        }

        public async Task<IEnumerable<string>> ObterEmpresaColeta()
        {
            var empresa = await _unitOfWork.EmpresaColetoraRepository.ObterTodosAsync();
            var orderedEmpresaColetaOrigem = empresa.OrderBy(o => o.Nome).ToList();
            
            return orderedEmpresaColetaOrigem;
        }

    }
}
