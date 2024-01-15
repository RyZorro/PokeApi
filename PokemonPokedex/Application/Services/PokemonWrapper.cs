using PokemonPokedex.Application.DTOs;

namespace PokemonPokedex.Application.Services
{
    /**
     * Implementation of IPokemonWrapper for PokemonDTO
     */
    public class PokemonWrapper : IPokemonWrapper<PokemonDTO>
    {
        /**
         * Wraps a PokemonDTO object.
         * @param pokemon The PokemonDTO object to be wrapped.
         * @return The wrapped PokemonDTO object.
         */
        public PokemonDTO Wrap(PokemonDTO pokemon)
        {
            return pokemon;
        }
    }
}