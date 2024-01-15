using PokemonPokedex.Domain.ValueObjects;

namespace PokemonPokedex.Domain.Entities
{
    public class Ability
    {
        //public AbilityDetails Ability { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
    }
}
