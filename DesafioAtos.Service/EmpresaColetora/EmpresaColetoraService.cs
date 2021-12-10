using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Infra.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAtos.Service.EmpresaColetora
{
    public class EmpresaColetoraService : IEmpresaColetoraService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpresaColetoraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task EmpresaColetoraPost(CriarEmpresaColetoraDto request)
        {
            try
            {
                var empresaColetora = _mapper.Map<EmpresaColetoraDto>(request);

                var empresaColetoraOrigem = new DesafioAtos.Domain.Entidades.EmpresaColetora
                {
                    Nome = request.Nome,
                    Categoria = request.Categoria,
                    Email = request.Email,
                    Cnpj = request.Cnpj,
                    Telefone = request.Telefone,
                    
                };

                await _unitOfWork.EmpresaColetoraRepository.CriarAsync(empresaColetoraOrigem);
                await _unitOfWork.SalvarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task EmpresaColetoraPut(EditarEmpresaColetoraDto request)
        {
            try
            {
                var empresaColetoraOrigem = _mapper.Map<EmpresaColetoraDto>(request);

                var empresaColetoraBanco = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(empresaColetoraOrigem.Id);

                empresaColetoraBanco.Status = request.Status;
                empresaColetoraBanco.Telefone = request.Telefone;
                empresaColetoraBanco.Email = request.Email;
                empresaColetoraBanco.Cnpj = request.Cnpj;
                empresaColetoraBanco.Nome = request.Nome;


                _unitOfWork.EmpresaColetoraRepository.Atualizar(empresaColetoraBanco);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletaEmpresaColetora(long id)
        {
            try
            {
                var empresaColetoraOrigem = await _unitOfWork.EmpresaColetoraRepository.ObterPorIdAsync(id);
                //_unitOfWork.ColetaRepository.RemoverAsync(empresaColetoraOrigem);
                await _unitOfWork.SalvarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmpresaColetoraDto> PegaEmpresaColetoraPorId(long id)
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

        public async Task<List<EmpresaColetoraDto>> PegaTodasEmpresaColetora()
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
    }
}
