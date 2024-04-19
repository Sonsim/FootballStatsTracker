using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using FootballStatsTrackerAPI.Data;
using FootballStatsTrackerAPI.Model;
using FootballStatsTrackerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IUserService _userService;

        public UserController(AppDbContext dbContext, IUserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }

        [HttpGet]
        [Route("/api/getTeams")]
        public ActionResult<IEnumerable<Teams>> GetTeams()
        {
            return _dbContext.teams.ToList();
        }

        [HttpGet]
        public async Task<ActionResult<User>> LoginUser([FromQuery] string username, [FromQuery] string password)
        {
            var user = await _userService.GetUsernameAndPasswordAsync(username, password);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
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
            return CreatedAtAction(nameof(GetUserByName), new { username = user.username, team=user.team, passwordhash= user.passwordhash, salt=user.salt}, user);
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
