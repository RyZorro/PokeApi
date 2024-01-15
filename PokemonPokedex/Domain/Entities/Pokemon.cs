using PokemonPokedex.Domain.ValueObjects;

namespace PokemonPokedex.Domain.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseExperience { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Version> GameIndices { get; set; }
        //public List<HeldItem> HeldItems { get; set; }
        public List<Move> Moves { get; set; }
        public Sprites sprites { get; set; } = new Sprites();
    }
}