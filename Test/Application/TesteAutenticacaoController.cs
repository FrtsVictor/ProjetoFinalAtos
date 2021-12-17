using System.Net;
using System.Threading.Tasks;
using DesafioAtos.Domain.Dtos;
using DesafioAtos.Service.Services.Autenticacao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Utils;

namespace Test.Application
{
    [TestClass]
    [TestCategory("AutenticacaoController")]
    public class TesteAutenticacaoController
    {
        [TestMethod]
        [TestCategory("Usuario")]
        public async Task Deve_Retornar_BadRequest_Para_Usuario_Com_Login_Incorreto()
        {
            var usuarioLoginErrado = new LogarUsuarioDto() {Login = "Test", Senha = "Teste"};
            var responseComLoginErrado = await UtilitarioHttp.HttpPostAsync(usuarioLoginErrado,
                EndpointAutenticacao.LoginUsuario);
            var responseBodyStr = await responseComLoginErrado.Content.ReadAsStringAsync();

            Assert.IsTrue(responseBodyStr.Contains(AutenticacaoService.UsuarioSenhaInvalidos));
            Assert.IsTrue(responseComLoginErrado.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestCategory("Usuario")]
        public async Task Deve_Retornar_BadRequest_Para_Usuario_Com_Senha_Incorreta()
        {
            var usuarioSenhaErrada = new LogarUsuarioDto() {Login = "Teste", Senha = "Test_"};
            var responseComSenhaErrada = await UtilitarioHttp.HttpPostAsync(usuarioSenhaErrada,
                EndpointAutenticacao.LoginUsuario);

            var responseBodyStr = await responseComSenhaErrada.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBodyStr.Contains(AutenticacaoService.UsuarioSenhaInvalidos));
            Assert.IsTrue(responseComSenhaErrada.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestCategory("AutenticacaoController")]
        public async Task Deve_Retornar_JwtToken_Para_Quando_Sucesso()
        {
            var loginUsuario = new LogarUsuarioDto() {Login = "Teste", Senha = "Teste"};
            var response = await UtilitarioHttp.HttpPostAsync(loginUsuario,
                EndpointAutenticacao.LoginUsuario);
            var responseBodyStr = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(responseBodyStr.Contains("token"));
        }
    }
}