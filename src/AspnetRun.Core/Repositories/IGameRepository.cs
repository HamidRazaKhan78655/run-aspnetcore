using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetGamesListAsync();
        Task<IEnumerable<Game>> GetGameByNameAsync(string gameName);
        Task<IEnumerable<Game>> GetGameByIdAsync(int gameId);
    }
}
