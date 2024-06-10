using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly List<User> _users;

        public UsersController(List<User> users = null)
        {
            _users = users ?? new List<User>
            {
                new User { Id = 1, FirstName = "Piotr", LastName = "Łysek", Role = "Programista" },
                new User { Id = 2, FirstName = "Jan", LastName = "Kowalski", Role = "Informatyk" },
                new User { Id = 3, FirstName = "Mirosław", LastName = "Sucharek", Role = "Ksiegowy" },
                new User { Id = 4, FirstName = "Tadeusz", LastName = "Dawny", Role = "Magazynier" }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Role = user.Role;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _users.Remove(user);

            return NoContent();
        }
    }
}