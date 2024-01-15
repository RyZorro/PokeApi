namespace PokemonPokedex.Domain.ValueObjects
{
    public class VersionGroupDetails
    {
        public int LevelLearnedAt { get; set; }
        public MoveLearnMethod MoveLearnMethod { get; set; }
        public VersionGroup VersionGroup { get; set; }
    }
}
