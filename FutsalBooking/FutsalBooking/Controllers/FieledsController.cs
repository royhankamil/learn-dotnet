using FutsalBooking.Dto;
using FutsalBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutsalBooking.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class FieledsController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("fields")]
        public IActionResult GetFields()
        {
            var fieds = _context.Fields.ToList();

            return Ok(fieds);
        }

        [HttpPost("fields")]
        public IActionResult PostFields(FieldsDto fieldsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var fields = _context.Fields.FirstOrDefault(f => f.name == fieldsDto.name);
            if (fields != null)
                return Conflict(new { message = "This name field already exist" });

            fields = new Fields()
            {
                name = fieldsDto.name,
                price = fieldsDto.price,
                status = fieldsDto.status
            };

            _context.Fields.Add(fields);
            _context.SaveChanges();
            return Ok(new { message = "Created new field successfully", data = fields});

        }


        [HttpPut("fields/{id}")]
        public IActionResult UpadateField(int id, [FromBody]FieldsDto fieldsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            Fields fields = _context.Fields.Find(id);
            if (fields == null)
                return NotFound(new { message = "Couldn't find field by given id" });


            Fields fieldsvalid = _context.Fields.FirstOrDefault(f => f.name == fieldsDto.name);
            if (fieldsvalid != null && fieldsvalid.id != id)
                return Conflict(new { message = "This name field already exist" });

            fields.name = fieldsDto.name;
            fields.price = fieldsDto.price;
            fields.status = fieldsDto.status;

            _context.Fields.Update(fields);
            _context.SaveChanges();
            return Ok(new { message = "updated successfully", data = fields});
        }

        [HttpDelete("fields/{id}")]
        public IActionResult DeleteField(int id)
        {
            Fields fields = _context.Fields.Find(id);
            if (fields == null)
                return NotFound(new { message = "Couldn't find user by given id" });

            _context.Fields.Remove(fields);
            _context.SaveChanges();
            return Ok(new { message = "deleted field successfully" });
        }

    }
}
