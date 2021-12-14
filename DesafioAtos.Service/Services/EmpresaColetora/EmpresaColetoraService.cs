using AutoMapper;
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Validacoes;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public class EmpresaColetoraService : IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork = null!;
        private readonly IMapper _mapper = null!;
        private readonly ICriptografo _criptografo = null!;
        private readonly IConfiguration _configuration = null!;
        private readonly string _chaveParaCriptografia = null!;

        public EmpresaColetoraService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICriptografo criptografo,
            string chaveParaCriptografia)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._chaveParaCriptografia = chaveParaCriptografia;
        }

        public async Task EmpresaColetoraPost(CriarEmpresaColetoraDto empresaColetoraDto)
        {
         
            var empresaColetora = _mapper.Map<EmpresaColetoraDto>(empresaColetoraDto);
            var verificarCnpj = ValidaCnpj.IsCnpj(empresaColetora.Cnpj);
            var verificaEmail = RegexUtilities.ValidaEmail(empresaColetora.Email);

            if(verificaEmail is true && verificarCnpj is true)
            {
                var empresaColetoraOrigem = new DesafioAtos.Domain.Entidades.EmpresaColetora
                {
                    Cnpj = empresaColetoraDto.Cnpj,
                    Email = empresaColetoraDto.Email,
                    Nome = empresaColetoraDto.Nome,
                    Telefone = empresaColetoraDto.Telefone

                };
            }
        }

        public async Task EmpresaColetoraPut(EditarEmpresaColetoraDto request)
        {
            var empresaColetoraOrigem = _mapper.Map<EmpresaColetoraDto>(request);
            var empresaColetoraBanco = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(empresaColetoraOrigem.Id);

            var verificarCnpj = ValidaCnpj.IsCnpj(empresaColetoraBanco.Cnpj);
            var verificaEmail = RegexUtilities.ValidaEmail(empresaColetoraBanco.Email);

            if (verificaEmail is true && verificarCnpj is true)
            {

                empresaColetoraBanco.Telefone = request.Telefone;
                empresaColetoraBanco.Email = request.Email;
                empresaColetoraBanco.Cnpj = request.Cnpj;
                empresaColetoraBanco.Nome = request.Nome;
                _unitOfWork.EmpresaColetoraRepository.Atualizar(empresaColetoraBanco);
            }

        }


        public async Task<EmpresaColetoraDto> GetEmpresaColetoraPorId(long id)
        {
            try
            {
                var empresaColetoraOrigin = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(id);
                var data = _mapper.Map<EmpresaColetoraDto>(empresaColetoraOrigin);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<EmpresaColetoraDto>> GetTodasEmpresaColetora()
        {
            try
            {
                var empresaColetoraOrigin = await _unitOfWork.EmpresaColetoraRepository.ObterTodosAsync();
                var ordenarEmpresaColetora = empresaColetoraOrigin.OrderBy(n => n.Nome).ToList();
                var data = _mapper.Map<List<EmpresaColetoraDto>>(ordenarEmpresaColetora);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletaEmpresaColetora(long id)
        {
            await _unitOfWork.ExecutarAsync(async () =>
            {
                await _unitOfWork.EmpresaColetoraRepository.RemoverAsync(id);
                return id;
            });
        }

    }
}
