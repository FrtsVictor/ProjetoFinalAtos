using DesafioAtos.Application.Core.ActionFilters;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
   
    /// <summary>
    /// Controller para autenticacao e criacao de Usuarios e EmpresaColetora
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    [ActionFilterValidacaoModelState]
    public class AutenticacaoController : AppControllerBase
    {
        /// <inheritdoc />
        public AutenticacaoController(IFabricaService fabricaService, IFabricaResponse fabricaResponse)
            : base(fabricaService, fabricaResponse)
        {
        }

        /// <summary>
        /// Login do Usuário
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("logar-usuario")]
        public async Task<IActionResult> LogarUsuario(LogarUsuarioDto loginDto) =>
            Ok(await _fabricaService.AutenticacaoService.LogarUsuario(loginDto));

        /// <summary>
        /// Login da Empresa
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("logar-empresa")]
        public async Task<IActionResult> LogarEmpresa(LogarEmpresaDto loginDto) =>
            Ok(_fabricaResponse.Criar(await _fabricaService.AutenticacaoService.LogarEmpresa(loginDto)));

        /// <summary>
        /// Criar Empresa.
        /// </summary>
        /// <param name="criarEmpresaColetoraDto"></param>
        /// <returns>Atualização da empresa</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /CriarEmpresa
        ///     {
        ///        "nome": "string",
        ///         "cnpj": "31.665.065/0001-80",
        ///         "telefone": "112345688",
        ///         "email": "string@string.com",
        ///         "senha": "string"
        ///          
        ///         "enderecos": [
        ///          {
        ///            "numero": "123A",
        ///            "complemento": "Galpão 2",
        ///            "rua": "Rua Trinta",
        ///            "cep": "03235000",
        ///            "cidade": "Cidade",
        ///            "estado": "Estado",
        ///            "bairro": "Bairro"
        ///          }
        ///         ],
        ///         "categorias": [0,3,8]
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPost("criar-empresa")]
        public async Task<IActionResult> CriarEmpresa(CriarEmpresaColetoraDto criarEmpresaColetoraDto)
        {
            var data = await _fabricaService.EmpresaColetoraService.CriarEmpresaColetora(criarEmpresaColetoraDto);
            return Created("", _fabricaResponse.Criar(data));
        }


        ///<summary>
        /// Criar Usuário.
        /// </summary>        /// 
        /// <param name="userDto"></param>
        /// <returns>Atualização do Usuário</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /CriarUsuario
        ///     {
        ///          "login": "login",
        ///          "senha": "senha",
        ///          "nome": "Nome"
        ///      }
        /// </remarks>
        /// <response code="201">Retorna criação ok</response>
        /// <response code="400">Se o request for nulo</response>
        [HttpPost("criar-usuario")]
        public async Task<IActionResult> CriarUsuario(CriarUsuarioDto userDto)
        {
            var user = await _fabricaService.UsuarioService.CriarUsuario(userDto);
            return Created("", _fabricaResponse.Criar(user.Id));
        }
    }
}