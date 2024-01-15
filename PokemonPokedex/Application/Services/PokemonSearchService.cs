using PokemonPokedex.Application.DTOs;
using PokemonPokedex.Infrastructure.ExternalService;

namespace PokemonPokedex.Application.Services
{
    /**
     * PokemonSearchService implements the IPokemonSearchService interface and provides search functionality
     */
    public class PokemonSearchService : IPokemonSearchService
    {
        // Private field to store an instance of IPokeApi
        private readonly IPokeApi _pokeApiService;

        /**
         * Constructor for PokemonSearchService.
         * @param pokeApiService An instance of IPokeApi used for accessing Pokemon data.
         */
        public PokemonSearchService(IPokeApi pokeApiService)
        {
            // Assign the provided IPokeApi instance to the private field
            _pokeApiService = pokeApiService;
        }

        /**
         * Searches for Pokemon in the given list based on the provided name.
         * @param allPokemon The list of all PokemonDTO objects to search within.
         * @param name The name to search for.
         * @return A list of PokemonDTO objects matching the search criteria.
         */
        public List<PokemonDTO> Search(List<PokemonDTO> allPokemon, string name)
        {
            // Check if the provided list is null
            if (allPokemon == null)
            {
                // Throw an ArgumentNullException if the list is null
                throw new ArgumentNullException(nameof(allPokemon));
            }

            // Perform case-insensitive search for Pokemon by name using LINQ
            var searchResults = allPokemon
                .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Return the list of search results
            return searchResults;
        }
    }
}