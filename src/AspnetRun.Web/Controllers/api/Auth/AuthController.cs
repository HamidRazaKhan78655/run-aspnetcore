using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IJWTManagerPageService _jWTManagerPageService;

        public AuthController(IProductPageService productPageService, IGamePageService gamePageService , IJWTManagerPageService jWTManagerPageService)
        {
            this._productPageService = productPageService;
            this._gamePageService = gamePageService;
            this._jWTManagerPageService = jWTManagerPageService;
        }
        public class Tokens
        {
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UsersViewModel usersdata)
        {
            var token = _jWTManagerPageService.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
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
