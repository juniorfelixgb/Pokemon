using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using PokemonBlazor.Models;

namespace PokemonBlazor.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _clientFactory;
        public Root Pokemon { get; set; } = new Root() { results = new List<Result>() };
        public Root PokemonInfo { get; set; } = new Root() { results = new List<Result>() };
        public PokemonService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        JsonSerializerOptions options = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };
        public async Task<Root> GetPokemons(int offset = 0, int limit = 0)
        {
            var client = _clientFactory.CreateClient("pokeapi");
            Pokemon = await client.GetFromJsonAsync<Root>($"pokemon?offset={offset}&limit={limit}", options, new CancellationToken());
            return Pokemon;
        }
        public async Task<Root> GetPokemon(int key = 0)
        {
            var client = _clientFactory.CreateClient("pokeapi");
            PokemonInfo = await client.GetFromJsonAsync<Root>($"pokemon/{key}", options, new CancellationToken());
            return PokemonInfo;
        }
    }
}