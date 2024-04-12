using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using FootballStatsTrackerAPI.Data;
using FootballStatsTrackerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(AppDbContext dbContext, ILogger<UserController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/getTeams")]
        public ActionResult<IEnumerable<Teams>> GetTeams()
        {
            return _dbContext.teams.ToList();
        }


        [HttpGet("{username}")]
        public ActionResult<User> GetUserByName(string username)
        {
            var user = _dbContext.users.Find(username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        [Route("/create-user")]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetUserByName), new { username = user.username, team=user.team, passwordhash= user.passwordhash }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int Id, [FromBody] User updatedUser)
        {
            var user = _dbContext.users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            user.team = updatedUser.team;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int Id)
        {
            var user = _dbContext.users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.users.Remove(user);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
