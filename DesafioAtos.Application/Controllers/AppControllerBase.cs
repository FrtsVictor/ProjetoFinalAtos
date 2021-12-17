using System.Security.Claims;
using DesafioAtos.Service.Fabrica.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioAtos.Application.Controllers
{
    /// <summary>
    /// Base controller para consumo comum de dependencias,
    /// a mesma ja possui fabrica de services e fabrica de responses
    /// </summary>
    public abstract class AppControllerBase : ControllerBase
    {
        /// <summary>
        /// Retorna Fabrica de services Scoped.
        /// </summary>
        protected readonly IFabricaService _fabricaService;

        /// <summary>
        /// Retorna Fabrica de response scoped.
        /// </summary>
        protected readonly IFabricaResponse _fabricaResponse;

        /// <inheritdoc />
        protected AppControllerBase(
            IFabricaService fabricaService,
            IFabricaResponse fabricaResponse)
        {
            this._fabricaService = fabricaService;
            this._fabricaResponse = fabricaResponse;
        }

        /// <summary>
        /// Obter Token
        /// </summary>
        /// <returns></returns>
        protected int ObterIdDoToken()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            return Convert.ToInt32(claimsIdentity?.FindFirst("id")?.Value);
        }
    }
}