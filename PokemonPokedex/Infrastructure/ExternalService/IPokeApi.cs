using PokemonPokedex.Application.DTOs;

namespace PokemonPokedex.Infrastructure.ExternalService
{
    /**
     * Defines a service contract for interacting with the Poke API
     */
    public interface IPokeApi
    {
        /**
         * Asynchronously retrieves information about all Pokemon.
         * @return A task representing the asynchronous operation. The result is a list of PokemonDTO objects.
         */
        Task<List<PokemonDTO>> GetAllPokemon();
    }
}