using AspnetRun.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IGamePageService
    {
        Task<IEnumerable<GameViewModel>> GetGames(string gameName);
        Task<GameViewModel> GetGameById(int gameId);
        Task<GameViewModel> CreateGame(GameViewModel gameViewModel);
        Task UpdateGame(GameViewModel gameViewModel);
        Task DeleteGame(GameViewModel gameViewModel);
    }
}
