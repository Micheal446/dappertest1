using dappertest1.models;

namespace DapperVideoGameDbNormalized.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation property
        public List<videogame> VideoGames { get; set; } = [];
    }

}
