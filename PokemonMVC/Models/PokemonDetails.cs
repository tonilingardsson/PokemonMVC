namespace PokemonMVC.Models
{
    public class PokemonDetails
    {
        public int Id { get; set; }
        public string Name = string.Empty;
        public int Height { get; set; }
        public int Width { get; set; }
        public string Base_Experience { get; set; }
        public PokemonSprites Sprites { get; set; } = new();
        public List<PokemonTypeEntry> Types { get; set; } = new();
    }

    public class PokemonSprites
    {
        public string? Front_Default { get; set; }
    }
    public class PokemonTypeEntry
    {
        public int Slot { get; set; }
        public NamedApiResource Type { get; set; } = new();
    }
}
