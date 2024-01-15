using PokemonPokedex.Domain.ValueObjects;

namespace PokemonPokedex.Application.DTOs
{
    /**
     * Represents a Data Transfer Object (DTO) for Pokemon information.
     * DTOs are used to transfer data between different layers of an application,
     * providing a lightweight and efficient way to communicate information.
     */
    public class PokemonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SpriteSet Sprites { get; set; } = new SpriteSet();
    }
}