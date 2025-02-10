using FutsalBooking.Dto;
using FutsalBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace FutsalBooking.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PaymentsController(DataContext _context) : Controller
    {
        DataContext _context = _context;

        [HttpPost("Payments")]
        public IActionResult PostPayments(PaymentsDto paymentsDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Reservations? reservations = _context.Reservations.FirstOrDefault(u => u.id == paymentsDto.reservation_id);
            if (reservations == default)
                return NotFound(new { message = "Couldn't find user by given user_id" });


            Payments payments = new Payments()
            {
                reservation_id = paymentsDto.reservation_id,
                amount = paymentsDto.amount,
                status = paymentsDto.status,
                created_at = DateTime.Now
            };

            _context.Payments.Add(payments);
            _context.SaveChanges();
            return Ok(new { message = "Created new reservations successfully", data = reservations });
        }

        [HttpGet("Payments")]
        public IActionResult GetPayments()
        {
            var payments = _context.Payments.ToList();
            return Ok(payments);
        }

    }
}
