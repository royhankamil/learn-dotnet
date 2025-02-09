using Microsoft.AspNetCore.Mvc;
using TestApi.Dto;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class CommentController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("Comment")]
        public IActionResult GetAllComment()
        {
            var data = _context.comment.ToList();
            return Ok(data);
        }

        [HttpGet("Comment/{id}")]
        public IActionResult GetCommentById(int id)
        {
            Comment? comment = _context.comment.Find(id);

            if (comment == null) 
                return NotFound(new {message = "couldn't find comment with given id"});

            Users? user = _context.users.Find(comment.user_id);
            comment.user = user;

            Books? book = _context.books.Find(comment.book_id);
            comment.book = book;

            return Ok(comment);
        }

        [HttpGet("Comment/User/{userid}")]
        public IActionResult GetCommentByUserId(int userid)
        {
            var comment = _context.comment.Where(c => c.user_id == userid).ToList();

            if (comment == null)
                return NotFound(new {message = "couldn't find userid by given userid"});

            foreach (var item in comment)
            {
                var book = _context.books.First(b => b.id == item.book_id);
                item.book = book;
            }

            return Ok(comment);
        }

        [HttpPost("Comment")]
        public IActionResult PostComment(CommentsDto commentDto)
        {
            if (commentDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users? user = _context.users.Find(commentDto.userId);

            if (user == null)
                return BadRequest(new {message = "couldn't find user by given userid"});

            Books? book = _context.books.Find(commentDto.bookId);

            if (book == null)
                return BadRequest(new { message = "couldn't find book by given bookid" });

            Comment? comment = new Comment()
            {
                user_id = commentDto.userId,
                book_id = commentDto.bookId,
                content = commentDto.content
            };

            _context.comment.Add(comment);
            _context.SaveChanges();

            return Ok(comment);
        }


        [HttpPut("Comment/{id}")]
        public IActionResult PutComment(int id, [FromBody] CommentsDto commentDto)
        {
            Comment? comment = _context.comment.Find(id);

            if (comment == null)
                return NotFound(new { message = "couldn't find comment with given id" });

            if (commentDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users? user = _context.users.Find(commentDto.userId);

            if (user == null)
                return BadRequest(new { message = "couldn't find user by given userid" });

            Books? book = _context.books.Find(commentDto.bookId);

            if (book == null)
                return BadRequest(new { message = "couldn't find book by given bookid" });

            comment.user_id = commentDto.userId;
            comment.book_id = commentDto.bookId;
            comment.content = commentDto.content;

            _context.comment.Update(comment);
            _context.SaveChanges();
            return Ok(comment);
        }

        [HttpDelete("Comment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            Comment? comment = _context.comment.Find(id);

            if (comment == null)
                return NotFound(new { message = "couldn't find comment with given id" });

            _context.comment.Remove(comment);
            _context.SaveChanges();
            return Ok(comment);
        }
    }
}
