namespace PokemonPokedex.Infrastructure.Http
{
    /**
     * Serves as a wrapper for making HTTP GET and POST requests
     */
    public class HttpClientWrapper: IHttpGetClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://pokeapi.co/api/v2/";

        /**
         * Constructor for HttpClientWrapper. Initializes the base URL and sets up default headers.
         */
        public HttpClientWrapper()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /**
         * Implements the GetAsync method to perform an HTTP GET request.
         * It ensures the response is successful and returns the content as a string.
         * @param requestUri The URI for the HTTP GET request.
         * @return A task representing the asynchronous operation. The result is the content of the HTTP response as a string.
         */
        public async Task<string> GetAsync(string requestUri)
        {
            var response = await _httpClient.GetAsync(requestUri);

            // Ensure that the HTTP response is successful; otherwise, throw an exception
            response.EnsureSuccessStatusCode();

            // Return the content of the HTTP response as a string
            return await response.Content.ReadAsStringAsync();
        }
    }
}