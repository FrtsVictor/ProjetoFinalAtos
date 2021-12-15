using System.Security.Claims;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    public abstract class AppControllerBase : ControllerBase
    {
        protected readonly IFabricaService _fabricaService;
        protected readonly IFabricaResponse _fabricaResponse;

        public AppControllerBase(
            IFabricaService fabricaService,
            IFabricaResponse fabricaResponse)
        {
            this._fabricaService = fabricaService;
            this._fabricaResponse = fabricaResponse;
        }

        protected int ObterIdDoToken()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity?.FindFirst("id")?.Value);
        }
    }
}