using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        [HttpPost]
        public IActionResult CreateUser(User user) {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status201Created, user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public  User GetUser(int id) {
            return _context.Users.Find(id);
        }

        [HttpPut]
        public IActionResult UpdateTheUser(User updateUser) {
            try
            {
                _context.Users.Update(updateUser);
                _context.SaveChanges(true);
                return StatusCode(StatusCodes.Status200OK);
            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
