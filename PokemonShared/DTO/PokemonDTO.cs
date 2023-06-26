using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonShared.DTO
{
    public class PokemonDTO
    {
        public int id { get; set; } = 0;
        public string name { get; set; } = string.Empty;
        public int weight { get; set; } = 0;
        public int height { get; set; } = 0;
        public string image { get; set; } = string.Empty;
    }
}
