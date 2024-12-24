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
            List<Ranking> Rankings = await _RankingContext.Rankings
                .Include(r => r.User)
                .OrderBy(r => r.CompletionTime)
                .Take(5)
                .ToListAsync();
            var lst = Rankings.Select(r => new RankingResponseDTO
            {
                ActivityId = r.ActivityId,
                UserName = r.User.UserName,
                CompletionTime = r.CompletionTime,
                DateTime = r.DateTime
            });
            return Ok(lst); 
        }

        [HttpPost]
        public async Task<IActionResult> PostRanking([FromBody]RankingRequestDTO rankingDTO)
        {
            var user = await _RankingContext.Users
                .FirstOrDefaultAsync(u => u.UserId == rankingDTO.UserId);
            if (user == null)
            {
                return NotFound();
            }
            var ranking = new Ranking
            {
                UserId = user.UserId,
                CompletionTime = rankingDTO.CompletionTime,
                DateTime = DateTime.Now
            };
            _RankingContext.Rankings.Add(ranking);
            await _RankingContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRankings), new { id = ranking.ActivityId }, ranking);
        }
    }
}
