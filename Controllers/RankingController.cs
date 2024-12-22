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
        private readonly RankingContext _RankingContext;
        public RankingsController(RankingContext RankingContext)
        {
            _RankingContext = RankingContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetRankings()
        {
            List<Ranking> Rankings = await _RankingContext.Rankings
                .OrderBy(r => r.CompletionTime)
                .Take(5)
                .ToListAsync();
            return Ok(Rankings); 
        }
    }
}
