using DapperVideoGameDbNormalized.Models;

namespace dappertest1.models
{
    public class VideoGamePlatform
    {
        public int VideoGameId { get; set; }
        public int PlatformId { get; set; }

        // Navigation properties
        public videogame? VideoGame { get; set; }
        public Platform? Platform { get; set; }

    }
}
