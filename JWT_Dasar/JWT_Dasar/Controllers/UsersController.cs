using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT_Dasar.Dto;
using JWT_Dasar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Dasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext _context, IConfiguration _config ) : Controller
    {
        DataContext _context = _context;
        IConfiguration _config = _config;

        private string ConvertToHash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool ValidityPassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }

        private string GenerateToken(Users user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSetting:Secret"]));
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserID.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Typ, user.Role),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JwtSetting:Issuer"],
                audience: _config["JwtSetting:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["JwtSetting:ExpirationMinutes"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var emailValid = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (emailValid != default)
                return Conflict(new { message = $"email {userDto.Email} already exist" });

            Users users = new Users()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = ConvertToHash(userDto.Password),
                Role = userDto.Role
            };
            _context.Users.Add(users);
            _context.SaveChanges();
            return Ok(new { message = "Registered Account Successfully"});
        }

        [HttpPost("Login")]
        public ActionResult Login(UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
            if (user == default)
                return NotFound(new {message = "Couldn't find user by given email"});

            if (!ValidityPassword(userDto.Password, user.Password))
                return Unauthorized(new { message = "Password is wrong, please try again"});

            var token = GenerateToken(user);
            return Ok(new { Token = token });
        }


    }
}
