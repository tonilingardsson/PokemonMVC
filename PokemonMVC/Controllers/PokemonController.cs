using Microsoft.AspNetCore.Mvc;
using PokemonMVC.Models;
using PokemonMVC.Services;

namespace PokemonMVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }
        public async Task<IActionResult> Index()
        {
            var pokemonList = await _pokemonService.GetPokemonListAsync();

            if (pokemonList == null) {
                // Handle the case where no Pokémon data is available
                ViewBag.ErrorMessage = "Unable to retrieve Pokémon data at this time. Please try again later.";
                return View(new PokemonListResponse
                {
                    Results = new List<NamedApiResource>()
                });
            }

            return View(pokemonList);
        }

        public async Task<IActionResult> Details(string id) 
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return View("NotFound");
            }

            var pokemon = await _pokemonService.GetPokemonDetailsAsync(id);
            
            if (pokemon == null) {
                return View("NotFound");
            }

            return View(pokemon);
        }

        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            if(string.IsNullOrWhiteSpace(searchTerm)) {
                return RedirectToAction(nameof(Index));
        }

            return RedirectToAction(nameof(Details), new { id = searchTerm.Trim().ToLower() });
        }
    }
}

