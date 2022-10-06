using AspnetRun.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Models
{
    public class GameModel : BaseModel
    {
        public string Name { get; set; }
        public string HighScore { get; set; }
    }
}
