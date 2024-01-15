using PokemonPokedex.Application.DTOs;
using PokemonPokedex.Domain.Entities;
using PokemonPokedex.Domain.ValueObjects;

namespace PokemonPokedex.Application.Mapper
{
    /**
     * Implements the IMapper interface for mapping Pokemon entities to PokemonDTO objects
     */
    public class PokemonMapper : IMapper<Pokemon, PokemonDTO>
    {
        /**
         * Maps a Pokemon entity to a PokemonDTO object.
         * @param pokemon The Pokemon entity to map.
         * @return The mapped PokemonDTO object.
         */
        public PokemonDTO Map(Pokemon pokemon)
        {
            // Create a new PokemonDTO object
            var pokemonDTO = new PokemonDTO
            {
                // Map properties from the Pokemon entity to PokemonDTO
                Id = pokemon.Id,
                Name = pokemon.Name,

                // Map Sprites property using a new SpriteSet
                Sprites = new SpriteSet
                {
                    FrontDefault = pokemon.sprites?.front_default,
                }
            };
            // Return the mapped PokemonDTO object
            return pokemonDTO;
        }
    }
}