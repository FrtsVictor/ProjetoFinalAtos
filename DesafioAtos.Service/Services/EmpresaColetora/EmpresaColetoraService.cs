using AutoMapper;
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Infra.UnitOfWorks;
using Microsoft.Extensions.Configuration;
using Np.Cryptography;

namespace DesafioAtos.Service.Services.EmpresaColetora
{
    public class EmpresaColetoraService : IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICriptografo _criptografo;
        private readonly IConfiguration _configuration;
        private readonly string _chaveParaCriptografia;

        public EmpresaColetoraService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            AppConfigEcoleta appConfigEcoleta,
            ICriptografo criptografo
           )
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._chaveParaCriptografia = appConfigEcoleta.PasswordKey();
        }

        public async Task EmpresaColetoraPost(CriarEmpresaColetoraDto empresaColetoraDto)
        {
            //var empresaParaCriacao = _mapper.MapEmpresaColetoraDtoToEmpresaColetora(empresaColetoraDto);

            //return await _unitOfWork.ExecutarAsync(async () =>
            //{
            //    return await _unitOfWork.Users.CriarAsync(empresaParaCriacao);
            //});


            var empresaColetora = _mapper.Map<EmpresaColetoraDto>(empresaColetoraDto);

            var empresaColetoraOrigem = new DesafioAtos.Domain.Entidades.EmpresaColetora
            {
                Cnpj = empresaColetoraDto.Cnpj,
                Email = empresaColetoraDto.Email,
                Nome = empresaColetoraDto.Nome,
                Telefone = empresaColetoraDto.Telefone

            };

            //await _unitOfWork.EmpresaColetoraRepository.CriarAsync(empresaColetoraOrigem);

            //await _unitOfWork.SalvarAsync();
        }

        public async Task EmpresaColetoraPut(EditarEmpresaColetoraDto request)
        {
            //await _unitOfWork.VoidExecutarAsync(async () =>
            //{
            //    var empresa = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(request.Id);
            //    _unitOfWork.EmpresaColetoraRepository.Atualizar(empresa);
            //    return empresa;
            //});


            var empresaColetoraOrigem = _mapper.Map<EmpresaColetoraDto>(request);

            var empresaColetoraBanco = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(empresaColetoraOrigem.Id);

            empresaColetoraBanco.Telefone = request.Telefone;
            empresaColetoraBanco.Email = request.Email;
            empresaColetoraBanco.Cnpj = request.Cnpj;
            empresaColetoraBanco.Nome = request.Nome;


            _unitOfWork.EmpresaColetoraRepository.Atualizar(empresaColetoraBanco);


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
