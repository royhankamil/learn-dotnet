using JWT_Dasar.Dto;
using JWT_Dasar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Dasar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(DataContext _context) : ControllerBase
    {
        DataContext _context = _context;

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("Books")]
        public IActionResult GetAllBooks()
        {
            var data = _context.Books.ToList();
            return Ok(data);
        }

        //[Authorize(Policy = "UserOnly")]
        [Authorize(Roles = "User")]
        [HttpGet("Books/{id}")]
        public IActionResult GetBookByID(int id)
        {
            Books? book = _context.Books.FirstOrDefault(b => b.BookID == id);

            if (book == default)
                return NotFound(new { message = "book id couldn't found" });

            return Ok(book);
        }

        [HttpPost("Books")]
        public IActionResult PostBook([FromBody] BooksDto booksDto)
        {
            if (booksDto == null)
                return BadRequest(new { message = "cannot create books with null" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Books book = new Books()
            {
                Title = booksDto.Title,
                Description = booksDto.Description,
                Author = booksDto.Author
            };

            _context.Books.Add(book);
            _context.SaveChanges();
            return Ok(book);

        }

        [HttpPut("Books/{id}")]
        public IActionResult PutBook(int id, [FromBody] BooksDto booksDto)
        {
            Books? book = _context.Books.Find(id);

            if (book == null)
                return NotFound(new { message = "book id couldn't found" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            book.Title = booksDto.Title;
            book.Description = booksDto.Description;
            book.Author = booksDto.Author;

            _context.Books.Update(book);
            _context.SaveChanges();
            return Ok(book);

        }

        [HttpDelete("Books/{id}")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            Books? book = _context.Books.FirstOrDefault(b => b.BookID == id);

            if (book == default)
                return NotFound(new { message = "book id couldn't found" });

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok(book);
        }

    }
}
