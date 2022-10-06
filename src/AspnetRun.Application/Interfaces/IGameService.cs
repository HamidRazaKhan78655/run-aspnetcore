using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameModel>> GetGameList();
        Task<GameModel> GetGameById(int gameId);
        Task<IEnumerable<GameModel>> GetGameByName(string gameName);
        Task<GameModel> Create(GameModel gameModel);
        Task Update(GameModel gameModel);
        Task Delete(GameModel gameModel);
    }
}