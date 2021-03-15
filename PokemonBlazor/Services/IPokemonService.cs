using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonBlazor.Models;

namespace PokemonBlazor.Services
{
    public interface IPokemonService
    {
         public Task<Root> GetPokemons(int offset = 0, int limit = 20);
         public Task<Root> GetPokemon(int key = 0);
         public Root Pokemon { get; set; }
         public Root PokemonInfo { get; set; }
    }
}