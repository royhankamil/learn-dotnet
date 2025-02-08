using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Dto;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class UsersController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("Users")]
        public ActionResult AllUsers()
        {
            var data = _context.users.ToList();
            return Ok(data);
        }

        [HttpGet("Users/{id}")]
        public ActionResult GetUsers(int id)
        {
            Users? user = _context.users.FirstOrDefault(u => u.id == id);

            if (user == default)
            {
                return NotFound(new {message = "id user  not found"});
            }

            //var books = _context.books.Where(b => b.creator_id == user.id).ToList();

            //user.Books = books;

            return Ok(user);

        }

        [HttpPost("Users")]
        public ActionResult PostUser(usersDto users)
        {
            if (users == null)
                return BadRequest(new {message = "user cannot be null"});

            var user = _context.users.FirstOrDefault(u => u.email.Trim().ToLower() == users.email.Trim().ToLower());

            if (user != null)
                return Conflict(new { message = "cannot post with registered email" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            user = new Users()
            {
                email = users.email,
                password = users.password,
                role = users.role
            };

            _context.users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPut("Users/{id}")]
        public ActionResult PutUser(int id, usersDto users)
        {
            var user = _context.users.FirstOrDefault(u => u.id == users.Id);
            if (user == default) return NotFound(new { message = "id user  not found" });

            var emailvalid = _context.users.FirstOrDefault(u => u.email.Trim().ToLower() == users.email.Trim().ToLower());

            if (emailvalid != null && emailvalid.id != id)
                return Conflict(new { message = "cannot put with registered email" });

            user.email = users.email;
            user.password = users.password;
            user.role = users.role;

            _context.users.Update(user);
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete("Users/{id}")]
        public ActionResult DeleteUser(int id)
        {
            Users? user = _context.users.FirstOrDefault(u => u.id == id);

            if (user == default)
            {
                return NotFound(new { message = "id user  not found" });
            }
            
            _context.users.Remove(user);
            _context.SaveChanges();
            return Ok(user);
        }

    }
}
