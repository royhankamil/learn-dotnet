using FutsalBooking.Dto;
using FutsalBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutsalBooking.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ReservationController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpGet("Reservations")]
        public IActionResult GetReservations()
        {
            var reservations = _context.Reservations.ToList();
            return Ok(reservations);
        }

        [HttpPost("Reservations")]
        public IActionResult PostReservations(ReservationsDto reservationsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Users? user = _context.Users.FirstOrDefault(u => u.id == reservationsDto.user_id);
            if (user == default)
                return NotFound(new { message = "Couldn't find user by given user_id" });

            Fields? field = _context.Fields.FirstOrDefault(u => u.id == reservationsDto.field_id);
            if (field == default)
                return NotFound(new { message = "Couldn't find field by given field_id" });


            Reservations reservations = new Reservations()
            {
                user_id = reservationsDto.user_id,
                field_id = reservationsDto.field_id,
                date = reservationsDto.date,
                start_time = reservationsDto.start_time,
                end_time = reservationsDto.end_time,
                status = reservationsDto.status,
                created_at = DateTime.Now
            };

            _context.Reservations.Add(reservations);
            _context.SaveChanges();
            return Ok(new { message = "Created new reservations successfully", data = reservations });
        }

        [HttpPut("Reservations/{id}/cancel")]
        public IActionResult UpadateReservations(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            Reservations reservations = _context.Reservations.Find(id);
            if (reservations == null)
                return NotFound(new { message = "Couldn't find reservations by given id" });



            reservations.status = "cancelled";

            _context.Reservations.Update(reservations);
            _context.SaveChanges();
            return Ok(new { message = "cancelling successfully", data = reservations });
        }

    }
}
