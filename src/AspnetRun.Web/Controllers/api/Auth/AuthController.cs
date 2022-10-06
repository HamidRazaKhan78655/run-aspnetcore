using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Controllers.api.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IProductPageService _productPageService;
        private readonly IGamePageService _gamePageService;

        public AuthController(IProductPageService productPageService, IGamePageService gamePageService)
        {
            this._productPageService = productPageService;
            this._gamePageService = gamePageService;
        }
        [HttpGet("Login")]
        public IEnumerable<string> Login()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Logout")]
        public IEnumerable<string> Logout()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("Game")]
        public async Task<IEnumerable<GameViewModel>> Game()
        {
            var list = await _gamePageService.GetGames("");
            return list;
        }
        [HttpGet("Products")]
        public async Task<IEnumerable<CategoryViewModel>> Products()
        {
            var list = await _productPageService.GetCategories();
            return list;
        }

    }
}
