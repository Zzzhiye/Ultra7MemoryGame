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
        private readonly MemoryGameContext _RankingContext;
        public RankingsController(MemoryGameContext RankingContext)
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

        [HttpPost("addRanking")]
        public async Task<IActionResult> PostRanking([FromBody] RankingRequestDTO rankingDTO)
        {
            var user = await _RankingContext.User
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRankings(long userId)
        {
            var user = await _RankingContext.User
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var userRankings = await _RankingContext.Rankings
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.DateTime)
                .ToListAsync();

            var rankingDtos = userRankings.Select(r => new RankingResponseDTO
            {
                ActivityId = r.ActivityId,
                UserName = user.UserName,
                CompletionTime = r.CompletionTime,
                DateTime = r.DateTime
            });

            return Ok(rankingDtos);
        }

        [HttpGet("top/user/{userId}")]
        public async Task<IActionResult> GetUserTopRanking(long userId)
        {
            var user = await _RankingContext.User
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var completionTime = await _RankingContext.Rankings
                .Where(r => r.UserId == userId)
                .OrderBy(r => r.CompletionTime)
                .Select(r => r.CompletionTime)
                .FirstOrDefaultAsync();

            return Ok(completionTime);
        }
    }
}
