namespace PokemonPokedex.Application.Services
{
    /**
     * Interface defining a contract for wrapping objects of type T
     */
    public interface IPokemonWrapper<T>
    {
        /**
         * Wraps an object of type T.
         * @param pokemon The object to be wrapped.
         * @return The wrapped object of type T.
         */
        T Wrap(T pokemon);
    }
}