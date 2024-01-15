using PokemonPokedex.Application.DTOs;

namespace PokemonPokedex.Application.Services
{
    /**
     * IPokemonSearchService interface defines a contract for searching Pokemon in a list
     */
    public interface IPokemonSearchService
    {
        /**
         * Searches for Pokemon in the given list based on the provided name.
         * @param allPokemon The list of all PokemonDTO objects to search within.
         * @param name The name to search for.
         * @return A list of PokemonDTO objects matching the search criteria.
         */
        List<PokemonDTO> Search(List<PokemonDTO> allPokemon, string name);
    }
}