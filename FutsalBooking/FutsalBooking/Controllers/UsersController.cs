using FutsalBooking.Dto;
using FutsalBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutsalBooking.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UsersController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("User/{id}")]
        public IActionResult GetUserById(int id)
        {
            Users? user = _context.Users.Find(id);

            if (user == null)
                return NotFound(new { message = "Couldn't find user by given id" });

            return Ok(user);
        }

        [HttpPost("User/login")]
        public IActionResult Login(LoginDto userdto)
        {
            if (userdto == null)
                return BadRequest();


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users? user = _context.Users.FirstOrDefault(u => u.email == userdto.email);
            if (user == default)
                return NotFound(new { message = "Couldn't find the account, please check your email" });

            if (user.password != userdto.password)
                return Unauthorized(new { message = "The password is wrong, try again later!" });

            return Ok(new {message = "user login successfully"});
        }

        [HttpPost("User/Register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users? user = _context.Users.FirstOrDefault(u => u.email == registerDto.email);

            if (user != default)
                return Conflict(new { message = "the email already registered" });

            user = new Users()
            {
                name = registerDto.name,
                email = registerDto.email,
                password = registerDto.password,
                role = "customer",
                created_at = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(new {message = "user created succcessfully"});
        }




        
    }
}
