using EMPTodoListBcknd.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMPTodoListBcknd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TaskController> _logger;
        private readonly DBContext _context;
        public UserController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _context.User.ToList();
        }

        // GET: api/Users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = _context.User.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }
        // PUT: api/Users
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(User user, int id)
        {
            if (user == null)
            {
                return BadRequest();
            }
            
            if (user.UserId != id)
                return BadRequest("ID Error not match with current User");

            try
            {
                _context.User.Update(user);
                _context.SaveChanges();
                return NoContent();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }

        // DELETE: api/Users
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                var user = _context.User.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
    
                _context.User.Remove(user);
                _context.SaveChanges();
                return NoContent();
            }
            catch (System.Exception)
            {
                throw new Exception("Algo paso mal...");
            }
        }

    }
}