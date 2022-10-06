using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace AspnetRun.Web.Services
{
    public class GamePageService : IGamePageService
    {
        private readonly IGameService _gameAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<GamePageService> _logger;

        public GamePageService(IGameService gameAppService,IMapper mapper, ILogger<GamePageService> logger)
        {
            this._gameAppService = gameAppService ?? throw new ArgumentNullException(nameof(gameAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GameViewModel>> GetGames(string gameName)
        {
            if (string.IsNullOrWhiteSpace(gameName))
            {
                var list = await _gameAppService.GetGameList();
                var mapped = _mapper.Map<IEnumerable<GameViewModel>>(list);
                return mapped;
            }

            var listByName = await _gameAppService.GetGameByName(gameName);
            var mappedByName = _mapper.Map<IEnumerable<GameViewModel>>(listByName);
            return mappedByName;
        }

        public async Task<GameViewModel> GetGameById(int gameId)
        {
            var product = await _gameAppService.GetGameById(gameId);
            var mapped = _mapper.Map<GameViewModel>(product);
            return mapped;
        }

        public async Task<GameViewModel> CreateGame(GameViewModel gameViewModel)
        {
            var mapped = _mapper.Map<GameModel>(gameViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            var entityDto = await _gameAppService.Create(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");

            var mappedViewModel = _mapper.Map<GameViewModel>(entityDto);
            return mappedViewModel;
        }

        public async Task UpdateGame(GameViewModel gameViewModel)
        {
            var mapped = _mapper.Map<GameModel>(gameViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _gameAppService.Update(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }

        public async Task DeleteGame(GameViewModel gameViewModel)
        {
            var mapped = _mapper.Map<GameModel>(gameViewModel);
            if (mapped == null)
                throw new Exception($"Entity could not be mapped.");

            await _gameAppService.Delete(mapped);
            _logger.LogInformation($"Entity successfully added - IndexPageService");
        }
    }
}
