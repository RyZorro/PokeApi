namespace PokemonPokedex.Infrastructure.Http
{
    /**
     * Defines an interface for making HTTP Requests
     */
    public interface IHttpGetClient
    {
        /**
         * Asynchronously performs an HTTP GET request.
         * @param requestUri The URI for the HTTP GET request.
         * @return A task representing the asynchronous operation. The result is the content of the HTTP response as a string.
         */
        Task<string> GetAsync(string requestUri);
    }
}