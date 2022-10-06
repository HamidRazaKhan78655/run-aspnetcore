using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IAppLogger<Game> _logger;

        public GameService(IGameRepository gameRepository, IAppLogger<Game> logger)
        {
            _gameRepository = gameRepository ?? throw new ArgumentNullException(nameof(gameRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<GameModel>> GetGameList()
        {
            var gameList = await _gameRepository.GetGamesListAsync();
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<GameModel>>(gameList);
            return mapped;
        }

        public async Task<GameModel> GetGameById(int gameId)
        {
            var game = await _gameRepository.GetByIdAsync(gameId);
            var mapped = ObjectMapper.Mapper.Map<GameModel>(game);
            return mapped;
        }

        public async Task<IEnumerable<GameModel>> GetGameByName(string gameName)
        {
            var gameList = await _gameRepository.GetGameByNameAsync(gameName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<GameModel>>(gameList);
            return mapped;
        }


        public async Task<GameModel> Create(GameModel gameModel)
        {
            await ValidateProductIfExist(gameModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Game>(gameModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _gameRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<GameModel>(newEntity);
            return newMappedEntity;
        }

        public async Task Update(GameModel gameModel)
        {
            ValidateProductIfNotExist(gameModel);

            var editGame = await _gameRepository.GetByIdAsync(gameModel.Id);
            if (editGame == null)
                throw new ApplicationException($"Entity could not be loaded.");

            ObjectMapper.Mapper.Map<GameModel, Game>(gameModel, editGame);

            await _gameRepository.UpdateAsync(editGame);
            _logger.LogInformation($"Entity successfully updated - AspnetRunAppService");
        }

        public async Task Delete(GameModel gameModel)
        {
            ValidateProductIfNotExist(gameModel);
            var deletedGame = await _gameRepository.GetByIdAsync(gameModel.Id);
            if (deletedGame == null)
                throw new ApplicationException($"Entity could not be loaded.");

            await _gameRepository.DeleteAsync(deletedGame);
            _logger.LogInformation($"Entity successfully deleted - AspnetRunAppService");
        }

        private async Task ValidateProductIfExist(GameModel gameModel)
        {
            var existingEntity = await _gameRepository.GetByIdAsync(gameModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{gameModel.ToString()} with this id already exists");
        }

        private void ValidateProductIfNotExist(GameModel gameModel)
        {
            var existingEntity = _gameRepository.GetByIdAsync(gameModel.Id);
            if (existingEntity == null)
                throw new ApplicationException($"{gameModel.ToString()} with this id is not exists");
        }

    }
}
