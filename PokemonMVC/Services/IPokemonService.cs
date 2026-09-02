using PokemonMVC.Models;

namespace PokemonMVC.Services
{
    public interface IPokemonService
    {

        Task<PokemonListResponse?> GetPokemonListAsync(int limit = 20);
        Task<PokemonDetails?> GetPokemonDetailsAsync(string name);
    }
}
