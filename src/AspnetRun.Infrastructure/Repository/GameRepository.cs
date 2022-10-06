using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Core.Specifications;
using AspnetRun.Core.Specifications.Base;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }


        public async Task<IEnumerable<Game>> GetGamesListAsync()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGameByNameAsync(string gameName)
        {
            return await _dbContext.Games.Where(x=>x.Name==gameName).ToListAsync();
        }

        public async Task<IEnumerable<Game>> GetGameByIdAsync(int gameId)
        {
            return await _dbContext.Games.Where(x => x.Id == gameId).ToListAsync();
        }

    }
}
