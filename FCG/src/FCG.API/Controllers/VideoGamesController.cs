using FCG.Data;
using FCG.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using FCG.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace FCG.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly DataContext _context;
        public VideoGamesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("VideoGames")]
        [Authorize]
        public async Task<ActionResult> GetVideoGames()
        {
            var videoGames = await _context.VideoGames.ToListAsync();

            return Ok(videoGames);
        }

        [HttpPost("VideoGames")]
        [Authorize]
        public async Task<ActionResult> PostVideoGames([FromBody]VideoGamesDto dto)
        {

            var videoGames = new VideoGames
            {
                Title = dto.Title,
                Developer = dto.Developer,
                Publisher = dto.Publisher,
                Genre = dto.Genre,
                InitialRelease = dto.InitialRelease,
                Price = dto.Price,
                DiscountPerc = dto.DiscountPerc,
                DiscountPrice = dto.Price - (dto.Price * dto.DiscountPerc / 100)
            };

            _context.VideoGames.Add(videoGames);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Jogo Cadastrado!" });
        }



    }
}
