using System.Collections.Generic;
using System.Linq;
using FootballStatsTrackerAPI.Data;
using FootballStatsTrackerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FootballStatsTrackerAPI.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            return _dbContext.Users.ToList();
        }

        [HttpGet]
        public ActionResult<User> GetUserByName(string userName)
        {
            var user = _dbContext.Users.Find(userName);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetUserByName), new { userName = user.UserName }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int Id, [FromBody] User updatedUser)
        {
            var user = _dbContext.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            user.FavoriteTeam = updatedUser.FavoriteTeam;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int Id)
        {
            var user = _dbContext.Users.Find(Id);
            if (user == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
