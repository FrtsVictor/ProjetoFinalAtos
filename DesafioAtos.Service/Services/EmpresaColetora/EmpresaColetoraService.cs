
using DesafioAtos.Domain.Core;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Mapper;
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

        public async Task Atualizar(EditarEmpresaColetoraDto atualizarEmpresaDto)
        {
            await _unitOfWork.VoidExecutarAsync(async () =>
            {
                var usuarioParaAtualizar = await _unitOfWork.Users.ObterPorIdAsync(atualizarEmpresaDto.Id);
                ValidarEntidade(usuarioParaAtualizar == null, "Falha ao encontrar usuario, verificar token");

                string senhaParaAtualizar = atualizarEmpresaDto.Cnpj;

                usuarioParaAtualizar.Login = atualizarUsuarioDto.Login ?? usuarioParaAtualizar.Login;

                usuarioParaAtualizar.Senha = string.IsNullOrEmpty(senhaParaAtualizar)
                    ? usuarioParaAtualizar.Senha
                    : _criptografo.Criptografar(_chaveParaCriptografia, senhaParaAtualizar);

                usuarioParaAtualizar.Nome = atualizarUsuarioDto.Nome ?? usuarioParaAtualizar.Nome;

                _unitOfWork.Users.Atualizar(usuarioParaAtualizar);
                return usuarioParaAtualizar;
            });


        }

        public Task<Domain.Entidades.EmpresaColetora> CriarEmpresaColetora(CriarEmpresaColetoraDto criarEmpresaDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ObterEmpresaColetora()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> ObterEmpresaColetoraId(long idEmpresa)
        {
            throw new NotImplementedException();
        }

        public Task RemoverEmpresaColetora(long id)
        {
            throw new NotImplementedException();
        }
    }
}
