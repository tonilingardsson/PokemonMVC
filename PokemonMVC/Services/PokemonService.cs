using System.Net;
using System.Net.Http.Json;
using PokemonMVC.Models;

namespace PokemonMVC.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://pokeapi.co/api/v2/pokemon";
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PokemonListResponse?> GetPokemonListAsync(int limit = 20)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PokemonListResponse>($"{BaseUrl}?limit={limit}");
            }
            catch
            {
                // Shall i add a message to the user or log it? ask Christoffer
                return null;  
            }
        }
        public async Task<PokemonDetails?> GetPokemonDetailsAsync(string name)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<PokemonDetails>($"{BaseUrl}/{name.ToLower()}");
            }
            // This catch is for http request exceptions, specifically for 404 Not Found errors.
            // It allows the application to handle cases where a Pokémon with the specified name does not exist in the API.
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                // Handle 404 Not Found (e.g., return null or a specific error message)
                return null;
            }
            // This catch is a fallback for any other exceptions that may occur during the HTTP request,
            // such as network issues or unexpected API responses.
            catch { return null; 
            }
        }
    }
}

