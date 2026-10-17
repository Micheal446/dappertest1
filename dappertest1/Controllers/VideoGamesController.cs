using dappertest1.models;
using DapperVideoGameDbNormalized.Models;
using DapperVideoGameDbNormalized.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DapperVideoGameDbNormalized.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGamesController : ControllerBase
    {
        private readonly IVideoGameRepository _videoGameRepository;

        public VideoGamesController(IVideoGameRepository videoGameRepository)
        {
            _videoGameRepository = videoGameRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<videogame>>> GetAllVideoGames()
        {
            var videoGames = await _videoGameRepository.GetAllVideoGamesAsync();
            return Ok(videoGames);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<videogame>>> GetVideoGame(int id)
        {
            var videoGame = await _videoGameRepository.GetVideoGameAsync(id);
            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult> CreateVideoGame(videogame videoGame)
        {
            if (videoGame == null)
                return BadRequest();

            var createdId = await _videoGameRepository.CreateVideoGameAsync(videoGame);
            return CreatedAtAction(nameof(GetVideoGame), new { id = createdId }, videoGame);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVideoGame(int id, videogame videoGame)
        {
            if (videoGame == null || videoGame.Id != id)
            {
                return BadRequest();
            }

            var existingVideoGame = await _videoGameRepository.GetVideoGameAsync(id);
            if (existingVideoGame == null)
            {
                return NotFound();
            }

            await _videoGameRepository.UpdateVideoGameAsync(videoGame);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVideoGame(int id)
        {
            var existingVideoGame = await _videoGameRepository.GetVideoGameAsync(id);
            if (existingVideoGame == null)
            {
                return NotFound();
            }

            await _videoGameRepository.DeleteVideoGameAsync(id);
            return NoContent();
        }
    }

}
