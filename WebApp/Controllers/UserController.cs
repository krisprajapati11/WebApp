using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private static List<User> users = new List<User>();
        //[HttpPost("create")]

        //public IActionResult CreateUser(User user)
        //{
        //    users.Add(user);
        //    return Ok("User created successfuly");
        //}
        //[HttpGet("all")]
        //public IActionResult GetAllUser()
        //{
        //    return Ok(users);
        //}

        ////[HttpGet(id)]
        //[HttpGet("{id}")]

        //public IActionResult GetUserById(int id)
        //{
        //    //var user = 
        //    var user = users.FirstOrDefault(x => x.Id == id);

        //        return Ok(user);
        //}
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpGet("all")]
        public IActionResult GetAllUseer()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id , User updateduser)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                return NotFound("User not found");
            }
            user.Name = updateduser.Name;
            user.Email = updateduser.Email;

            _context.SaveChanges();

            return Ok(user);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound("user not found ");

            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok("user deleted successfully");
            
        }

    }
}
