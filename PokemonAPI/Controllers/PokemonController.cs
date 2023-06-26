using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonShared.DTO;
using System.Text.Json;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        [HttpGet("ObtenerPorNombre/{nombre}")]
        public async Task<PokemonDTO?> ObtenerPorNombre(string nombre)
        {
            var pokemon = new PokemonDTO();

            var peticion = new HttpClient();
            var respuesta = await peticion.GetAsync($"https://pokeapi.co/api/v2/pokemon/{nombre}");

            if(respuesta.IsSuccessStatusCode)
            {
                var contenido = await respuesta.Content.ReadAsStringAsync();
                pokemon = JsonSerializer.Deserialize<PokemonDTO>(contenido);

                if (pokemon != null)
                {
                    pokemon.image = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{pokemon.id}.png";
                }

            }
            else if ((int)respuesta.StatusCode == 404)
            {
                pokemon.name = "Not found.";
               
            }

            return pokemon;
        }
    }
}
