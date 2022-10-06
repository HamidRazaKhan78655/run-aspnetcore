using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Core.Entities
{
    public class Game : Entity
    {
        public Game()
        {
        }

        public string Name { get; set; }
        public string HighScore { get; set; }

        public static Game Create(int GameId, string name, string HighScore )
        {
            var game = new Game
            {
                Id = GameId,
                Name = name,
                HighScore = HighScore,
            };
            return game;
        }
    }
}