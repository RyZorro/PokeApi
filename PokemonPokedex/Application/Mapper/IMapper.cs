namespace PokemonPokedex.Application.Mapper
{
    /**
     * Represents a generic IMapper interface for mapping between different types.
     * @typeparam TSource The source type.
     * @typeparam TDestination The destination type.
     */
    public interface IMapper<TSource, TDestination>
    {
        /**
         * Maps a source object to a destination object.
         * @param source The source object to map.
         * @return The mapped destination object.
         */
        TDestination Map(TSource source);
    }
}