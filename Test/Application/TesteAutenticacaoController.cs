using System;
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
            var responseComLoginErrado = await UtilitarioTest.HttpPostAsync(usuarioLoginErrado,
                EndpointAutenticacao.LoginUsuario, HttpStatusCode.OK);
            var responseBodyStr = await responseComLoginErrado.Content.ReadAsStringAsync();

            Assert.IsTrue(responseBodyStr.Contains(AutenticacaoService.UsuarioSenhaInvalidos));
            Assert.IsTrue(responseComLoginErrado.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestCategory("Usuario")]
        public async Task Deve_Retornar_BadRequest_Para_Usuario_Com_Senha_Incorreta()
        {
            var usuarioSenhaErrada = new LogarUsuarioDto() {Login = "Teste", Senha = "Test_"};
            var responseComSenhaErrada = await UtilitarioTest.HttpPostAsync(usuarioSenhaErrada,
                EndpointAutenticacao.LoginUsuario, HttpStatusCode.OK);

            var responseBodyStr = await responseComSenhaErrada.Content.ReadAsStringAsync();
            Assert.IsTrue(responseBodyStr.Contains(AutenticacaoService.UsuarioSenhaInvalidos));
            Assert.IsTrue(responseComSenhaErrada.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        [TestCategory("AutenticacaoController")]
        public async Task Deve_Retornar_JwtToken_Para_Quando_Sucesso()
        {
            var loginUsuario = new LogarUsuarioDto() {Login = "Teste", Senha = "Teste"};
            var response = await UtilitarioTest.HttpPostAsync(loginUsuario,
                EndpointAutenticacao.LoginUsuario, HttpStatusCode.OK);
            var responseBodyStr = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.IsSuccessStatusCode);
            Assert.IsTrue(responseBodyStr.Contains("token"));
        }
    }
}