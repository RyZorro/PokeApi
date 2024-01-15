using PokemonPokedex.Domain.ValueObjects;

namespace PokemonPokedex.Domain.Entities
{

    namespace PokeRestfulApi.Domain.Entities
    {
        public class PokemonList
        {
            public int Count { get; set; }

            public string Next { get; set; }

            public string Previous { get; set; }

            public List<PokemonInfo> Results { get; set; }
        }

        public class PokemonInfo
        {
            public string Name { get; set; }

            public string Url { get; set; }
            public Sprites Sprites { get; set; }
        }
    }
}