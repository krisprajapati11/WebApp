using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.DTOs;
using WebApp.Services;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Authorization;

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
        private readonly IUserService _userService;

        public UserController(AppDbContext context , IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDto dto)
        {
            //if(user.Id != 0)
            //{
            //    return BadRequest("Id should be auto generated");
            //}
            //var user = new User
            //{
            //    Name = dto.Name,
            //    Email = dto.Email
            //};
            //_context.Users.Add(user);
            //_context.SaveChanges();

            //return Ok(user);

            var user = _userService.CreateUser(dto);
            return Ok(user);
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetAllUseer()
        {
            //var users = _context.Users.ToList();
            return Ok(_userService.GetAllUsers());
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateUserDto dto)
        {
            var user = _userService.UpdateUser(id, dto);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteUser(int id)
        {
            var user = _userService.DeleteUser(id);

            if(!user)
                return NotFound();
            return Ok("user deleted successfully");

        }

    }
}
