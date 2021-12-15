﻿using DesafioAtos.Domain.Dtos;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Domain.Mapper;
using DesafioAtos.Infra.UnitOfWorks;
using DesafioAtos.Service.Exceptions;
using DesafioAtos.Service.Services.Token;
using Np.Cryptography;

namespace DesafioAtos.Service.Services.Autenticacao
{
    public class AutenticacaoService : IAutenticacaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICriptografo _criptografo;
        private readonly string _passwordKey;
        private readonly ITokenService _tokenService;

        public AutenticacaoService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICriptografo criptografo,
            ITokenService tokenService,
            string passwordKey)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._criptografo = criptografo;
            this._tokenService = tokenService;
            _passwordKey = passwordKey;
        }

        public async Task<TokenResponseDto> LogarUsuario(LogarUsuarioDto loginDto)
        {
            var usuario = await _unitOfWork.Users.ObterPorLoginAsync(loginDto.Login);
            ValidarEntidade(usuario);
            ValidarSenha(loginDto.Senha, usuario.Senha);

            var createTokenDto = _mapper.MapUsuarioToCreateTokenDto(usuario);
            return _tokenService.CriarToken(createTokenDto);
        }

        public async Task<TokenResponseDto> LogarEmpresa(LogarEmpresaDto loginDto)
        {
            var empresaColetora = await _unitOfWork.EmpresaColetoraRepository.ObterPorEmail(loginDto.Email);
            ValidarEntidade(empresaColetora);
            ValidarSenha(empresaColetora.Senha, loginDto.Senha);

            var createTokenDto = _mapper.MapCriarEmpresaColetoraDtoToCreateTokenDto(empresaColetora);
            return _tokenService.CriarToken(createTokenDto);
        }

        private void ValidarSenha(string senhaLogin, string senhaSalvaNoBanco)
        {
            var senhaLoginCriptografada = _criptografo.Criptografar(_passwordKey, senhaLogin);
            bool isSenhaInvalida = !senhaSalvaNoBanco.Equals(senhaLoginCriptografada);

            if (isSenhaInvalida)
                throw new BadRequestException("Usuario ou senha inválida!");
        }

        private void ValidarEntidade<T>(T entity)
        {
            if (entity == null)
                throw new BadRequestException("Usuario ou senha inválida!");
        }
    }
}