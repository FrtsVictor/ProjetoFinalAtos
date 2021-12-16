using System;
using System.Threading.Tasks;
using DesafioAtos.Domain.Dtos.Token;
using DesafioAtos.Service.Services.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Utils;

namespace Test.Application
{
    [TestClass]
    [TestCategory("UsuarioController")]
    public class TestUsuarioControler
    {
        [TestMethod]
        [TestCategory("Usuario")]
        public async Task Deve_Retornar_BadRequest_Para_Usuario_Com_Login_Incorreto()
        {
            try
            {
                var config = new TestSettings().Configuration;
                var a = config["cryptography:AppPasswordKey"];
                var b = ".";
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}