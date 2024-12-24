using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemoryGame.Data;

namespace MemoryGame.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AdsController : ControllerBase
    {

        private readonly MemoryGameContext _dbContext;

        public AdsController(MemoryGameContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{UserId}/paid-status")]
        public IActionResult GetPaidStatus(int UserId)
        {
            var user = _dbContext.User.FirstOrDefault(u => u.UserId == UserId);
            if (user == null)
            {
                return NotFound(new {message = "User not found"});
            }

            return Ok( new { isPaid = user.IsPaid});
        }
    }
}
