using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokemonPokedex.Application.DTOs;
using PokemonPokedex.Application.Services;
using PokemonPokedex.Infrastructure.ExternalService;

namespace PokemonPokedex.Web.Views
{
    /**
     * Represents the Model for the Index Razor Page. This class fetches all Pokemon data from the API and prepares it for rendering in the Index view.
     */
    public class IndexModel : PageModel
    {
        private readonly IPokeApi _pokemonRepository;
        private readonly IPokemonSearchService _pokemonSearchService;

        /**
         * Constructor for the IndexModel class.
         * @param pokemonRepository An instance of IPokeApi used for fetching Pokemon data from the API.
         * @param pokemonSearchService An instance of IPokemonSearchService used for searching Pokemon in the list.
         */
        public IndexModel(IPokeApi pokemonRepository, IPokemonSearchService pokemonSearchService)
        {
            _pokemonRepository = pokemonRepository;
            _pokemonSearchService = pokemonSearchService;
        }

        /**
         * Property representing the list of PokemonDTO objects to be rendered in the Index view.
         */
        public List<PokemonDTO> AllPokemonDTO { get; set; }

        /**
         * Property representing the search query entered by the user.
         */
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        /**
         * Handles the HTTP GET request for the Index page.
         * Fetches all Pokemon data from the API and applies search filtering based on the user-entered query.
         */
        public async Task OnGetAsync()
        {
            // Fetch all Pokemon data from the API
            var allPokemon = await _pokemonRepository.GetAllPokemon();

            // Apply search filtering if a search query is provided
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                allPokemon = _pokemonSearchService.Search(allPokemon, SearchQuery);
            }

            // Set the property for rendering in the Index view
            AllPokemonDTO = allPokemon;
        }
    }
}