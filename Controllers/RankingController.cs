using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Data;
using MemoryGame.Models;

namespace MemoryGame.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingsController : ControllerBase
    {
        private readonly GameContext _RankingContext;
        public RankingsController(GameContext RankingContext)
        {
            _RankingContext = RankingContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRankings()
        {
            List<Ranking> Rankings = await _RankingContext.Rankings.ToListAsync();
            return Ok(Rankings); 
        }
    }
}
