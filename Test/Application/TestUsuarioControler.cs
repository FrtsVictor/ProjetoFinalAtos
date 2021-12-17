using System;
using System.Net;
using System.Threading.Tasks;
using DesafioAtos.Domain.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Utils;

namespace Test.Application
{
    [TestClass]
    [TestCategory("UsuarioController")]
    public class TestUsuarioControler
    {
       
        [TestMethod]
        [TestCategory("CriarUsuario")]
        public async Task Deve_Criar_Usuario_Com_Sucesso()
        {
            var criarUsuarioDto = new CriarUsuarioDto()
            {
                Login = DateTime.Now.ToString(), Nome = "Test__", Senha = "Test__"
            };

            var response = await UtilitarioHttp.HttpPostAsync(criarUsuarioDto, EndpointUsuario.Usuario);
            var responseBodyStr = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);
        }


        [TestMethod]
        [TestCategory("AdicionarCategoria")]
        public async Task Test()
        {
            try
            {
                var url = $"{EndpointUsuario.CategoriaUsuario}1";
                var _provedorServices = new ProvedorServices();
                var token = await _provedorServices.ObterToken();
                var response = await UtilitarioHttp.HttpPostAsync("",url, token );
                var responseBodyStr = await response.Content.ReadAsStringAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}