using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Dto;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/controller")]
    public class BooksController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("Books")]
        public IActionResult GetAllBooks()
        {
            var data = _context.books.ToList();
            return Ok(data);
        }

        [HttpGet("Books/{id}")]
        public IActionResult GetBookByID(int id)
        {
            Books? book = _context.books.FirstOrDefault(b => b.id == id);

            if (book == default) 
                return NotFound(new { message = "book id couldn't found"});

            //var user = _context.users.First(u => u.id == book.creator_id);
            //book.creator = user;
            return Ok(book);
        }

        [HttpPost("Books")]
        public IActionResult PostBook([FromBody] BooksDto booksDto)
        {
            if (booksDto == null)
                return BadRequest( new { message = "cannot create books with null" });

            Users? user = _context.users.FirstOrDefault(u=>u.id == booksDto.creatorId);
            if (user == default)
                return NotFound(new { message = "couldn't find the creator by id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Books book = new Books()
            {
                creator_id = booksDto.creatorId,
                title = booksDto.Title,
                description = booksDto.Description,
                category = booksDto.category
            };

            _context.books.Add(book);
            _context.SaveChanges();
            return Ok(book);

        }

        [HttpPut("Books/{id}")]
        public IActionResult PutBook(int id, [FromBody] BooksDto booksDto)
        {
            Books? book = _context.books.Find(id);

            if (book == null)
                return NotFound(new { message = "book id couldn't found" });

            Users? user = _context.users.FirstOrDefault(u => u.id == booksDto.creatorId);
            if (user == default)
                return NotFound(new { message = "couldn't find the creator by id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            book.creator_id = booksDto.creatorId;
            book.title = booksDto.Title;
            book.description = booksDto.Description;
            book.category = booksDto.category;

            _context.books.Update(book);
            _context.SaveChanges();
            return Ok(book);

        }

        [HttpDelete("Books/{id}")]
        public IActionResult DeleteBook([FromQuery] int id)
        {
            Books? book = _context.books.FirstOrDefault(b => b.id == id);

            if (book == default)
                return NotFound(new { message = "book id couldn't found" });

            _context.books.Remove(book);
            _context.SaveChanges();
            return Ok(book);
        }

    }
}
