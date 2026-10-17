using dappertest1.models;

namespace DapperVideoGameDbNormalized.Models
{
    public class GameDetail
    {
        public int VideoGameId { get; set; }
        public required string Description { get; set; }
        public required string Rating { get; set; }

        // Navigation property
        public videogame? VideoGame { get; set; }
    }

}
