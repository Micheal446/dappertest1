using dappertest1.models;
using DapperVideoGameDbNormalized.Models;

namespace DapperVideoGameDbNormalized.Repositories
{
    public interface IVideoGameRepository
    {
        Task<int> CreateVideoGameAsync(videogame videoGame);
        Task<videogame> GetVideoGameAsync(int id);
        Task<IEnumerable<videogame>> GetAllVideoGamesAsync();
        Task UpdateVideoGameAsync(videogame videoGame);
        Task DeleteVideoGameAsync(int id);
    }
}
