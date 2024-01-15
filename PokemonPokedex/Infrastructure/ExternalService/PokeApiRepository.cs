using PokemonPokedex.Application.DTOs;
using PokemonPokedex.Application.Mapper;
using PokemonPokedex.Application.Services;
using PokemonPokedex.Domain.Entities;
using PokemonPokedex.Domain.Entities.PokeRestfulApi.Domain.Entities;
using PokemonPokedex.Infrastructure.Http;
using System.Text.Json;

namespace PokemonPokedex.Infrastructure.ExternalService
{
    /**
     * Interacts with Poke API
     */
    public class PokeApiRepsoitory : IPokeApi
    {
        // Private fields for dependencies
        private readonly IHttpGetClient _httpGetClient;
        private readonly IMapper<Pokemon, PokemonDTO> _pokemonMapper;
        private readonly IPokemonWrapper<PokemonDTO> _pokemonWrapper;

        /**
         * Constructor for PokeApiRepository.
         * @param httpGetClient An instance of IHttpGetClient used for making HTTP GET requests.
         * @param pokemonMapper An instance of IMapper used for mapping Pokemon entities to PokemonDTO objects.
         * @param pokemonWrapper An instance of IPokemonWrapper used for wrapping PokemonDTO objects.
         */
        public PokeApiRepsoitory(IHttpGetClient httpGetClient, IMapper<Pokemon, PokemonDTO> pokemonMapper, IPokemonWrapper<PokemonDTO> pokemonWrapper)
        {
            // Initialize dependencies, throwing ArgumentNullException if any parameter is null
            _httpGetClient = httpGetClient;
            _pokemonMapper = pokemonMapper;
            _pokemonWrapper = pokemonWrapper;
        }

        /**
         * Asynchronously retrieves information about all Pokemon.
         * @return A task representing the asynchronous operation. The result is a list of PokemonDTO objects.
         */
        public async Task<List<PokemonDTO>> GetAllPokemon()
        {
            try
            {
                // Make an asynchronous HTTP GET request to fetch information about all Pokemon
                var allPokemonInfo = await _httpGetClient.GetAsync("pokemon?limit=5");

                // Check if the response is empty or null, handle error or return an empty list
                if (string.IsNullOrEmpty(allPokemonInfo))
                {
                    // Handle error or return an empty list
                    return new List<PokemonDTO>();
                }

                // Deserialize the response into a PokemonList object
                var pokemonListResponse = JsonSerializer.Deserialize<PokemonList>(allPokemonInfo, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Deserialize the response into a PokemonList object
                var pokemonUrls = pokemonListResponse?.Results?.Select(p => p.Url)?.ToList();
                var allPokemonDTO = new List<PokemonDTO>();

                // Iterate over each Pokemon URL
                if (pokemonUrls != null)
                {
                    foreach (var url in pokemonUrls)
                    {
                        // Make an asynchronous HTTP GET request to fetch information about an individual Pokemon
                        var pokemonInfo = await _httpGetClient.GetAsync(url);

                        // Check if the response for an individual Pokemon is not empty or null
                        if (!string.IsNullOrEmpty(pokemonInfo))
                        {
                            // Deserialize the response into a Pokemon object
                            var pokemon = JsonSerializer.Deserialize<Pokemon>(pokemonInfo, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });

                            // Map the Pokemon object to a PokemonDTO object
                            var pokemonDTO = _pokemonMapper.Map(pokemon);

                            // Wrap the PokemonDTO object using the provided wrapper
                            var wrappedPokemon = _pokemonWrapper.Wrap(pokemonDTO);

                            // Add the wrapped PokemonDTO to the list
                            allPokemonDTO.Add(wrappedPokemon);
                        }
                        else
                        {
                            // Handle error or continue with the next Pokemon
                        }
                    }
                }

                // Return the list of all wrapped PokemonDTO objects
                return allPokemonDTO;
            }
            catch (Exception ex)
            {
                // Log the exception or rethrow based on your error handling strategy
                throw;
            }
        }
    }
}