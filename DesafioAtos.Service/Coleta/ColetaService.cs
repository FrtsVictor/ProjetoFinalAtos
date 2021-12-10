using AutoMapper;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Infra.UnitOfWorks;

namespace DesafioAtos.Service.Coleta
{
    public class ColetaService : IColetaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ColetaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task ColetaPost(CriarColetaDto request)
        {
            try
            {
                var coleta = _mapper.Map<ColetaDto>(request);

                var coletaOrigem = new DesafioAtos.Domain.Entidades.Coleta
                {
                    Nome = request.Nome,
                    ItemDeColeta = request.ItemDeColeta,
                    Observacao = request.Observacao,
                    Categoria = request.Categoria,
 
                };

                await _unitOfWork.ColetaRepository.CriarAsync(coletaOrigem);
                await _unitOfWork.SalvarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task ColetaPut(EditarColetaDto request)
        {
            try
            {
                var coletaOrigem = _mapper.Map<ColetaDto>(request);

                var coletaBanco = await _unitOfWork.ColetaRepository.ObterPorIdAsync(coletaOrigem.Id);

                coletaBanco.ItemDeColeta = request.ItemDeColeta;
                coletaBanco.Nome = request.Nome;
                coletaBanco.Status = request.Status;
                coletaBanco.Categoria = request.Categoria;
                coletaBanco.Observacao = request.Observacao;

         
            
                _unitOfWork.ColetaRepository.Atualizar(coletaBanco);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<List<ColetaDto>> PegaTodasColeta()
        {
            try
            {
                var coletaOrigin = await _unitOfWork.ColetaRepository.ObterTodosAsync();
                var ordenarColeta = coletaOrigin.OrderBy(n => n.Nome).ToList();
                var data = _mapper.Map<List<ColetaDto>>(ordenarColeta);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ColetaDto> PegaColetaPorId(long id)
        {
            try
            {
                var coletaOrigin = await _unitOfWork.ColetaRepository.ObterPorIdAsync(id);
                var data = _mapper.Map<ColetaDto>(coletaOrigin);
                return data;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletaColeta(long id)
        {
            try
            {
                var coletaOrigem = await _unitOfWork.ColetaRepository.ObterPorIdAsync(id);
                //_unitOfWork.ColetaRepository.RemoverAsync(coletaOrigem);
                await _unitOfWork.SalvarAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}

