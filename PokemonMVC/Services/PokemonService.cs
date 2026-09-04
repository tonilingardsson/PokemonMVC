using System.Net;
using System.Net.Http.Json;
using PokemonMVC.Models;

namespace PokemonMVC.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PokemonService> _logger;

        private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";

        public PokemonService(
            HttpClient httpClient,
            ILogger<PokemonService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<PokemonListResponse?> GetPokemonListAsync(int limit = 20)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PokemonListResponse>(
                    $"{BaseUrl}?limit={limit}");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(
                    ex,
                    "Could not load the Pokémon list from PokéAPI.");

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unexpected error happened while loading the Pokémon list.");

                return null;
            }
        }

        public async Task<PokemonDetails?> GetPokemonDetailsAsync(string name)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PokemonDetails>(
                    $"{BaseUrl}/{name.ToLowerInvariant()}");
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning(
                    "Pokémon '{PokemonName}' was not found.",
                    name);

                return null;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(
                    ex,
                    "Could not load Pokémon '{PokemonName}' from PokéAPI.",
                    name);

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unexpected error happened while loading Pokémon '{PokemonName}'.",
                    name);

                return null;
            }
        }
    }
}