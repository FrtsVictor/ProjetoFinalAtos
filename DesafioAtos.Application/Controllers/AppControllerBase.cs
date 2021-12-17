using System.Security.Claims;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    public abstract class AppControllerBase : ControllerBase
    {
        protected readonly IFabricaService _fabricaService;
        protected readonly IFabricaResponse _fabricaResponse;

<<<<<<< HEAD
        protected AppControllerBase(
=======
        public AppControllerBase(
>>>>>>> a4c0c85 (datanotation)
            IFabricaService fabricaService,
            IFabricaResponse fabricaResponse)
        {
            this._fabricaService = fabricaService;
            this._fabricaResponse = fabricaResponse;
        }
<<<<<<< HEAD

=======
        /// <summary>
        /// Obter Token
        /// </summary>
        /// <returns></returns>
>>>>>>> a4c0c85 (datanotation)
        protected int ObterIdDoToken()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity?.FindFirst("id")?.Value);
        }
    }
}