using esemkarailways.Data;
using esemkarailways.Dto;
using esemkarailways.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esemkarailways.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TicketController : Controller
    {
        DataContext _context;
        public TicketController(DataContext _context) => this._context = _context;

        [HttpGet("Schedule/Passenger/{PassengerID}")]
        public IActionResult GetScheduleByPassengerID(int PassengerID, int? trainID, DateTime? departureDate )
        {
            var data = _context.ticket
                .Include(u => u.Passenger)
                .Include(u => u.Schedule)
                .Where(u => u.PassengerID == PassengerID)
                .Select(i => new
                {
                    i.TicketID,
                    i.Schedule.TrainID,
                    i.Passenger.FirstName,
                    i.Passenger.LastName,
                    i.SeatNumber,
                    i.BookingTime,
                    i.Schedule.DepartureTime,
                    i.Schedule.ArrivalTime
                 })
                .ToList();

            if (trainID != null)
                data = data.Where(t => t.TrainID == trainID).ToList();

            if (departureDate != null)
                data = data.Where(d => d.DepartureTime.Date == departureDate.Value.Date).ToList();

            return Ok(data);
        }

        [HttpPost("Ticket")]
        public IActionResult PostTicket(TicketDto ticketDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Passenger? passenger = _context.passenger.Find(ticketDto.PassengerID);
            if (passenger == null)
                return NotFound(new { message = "Couldn't find Passenger by given ID" });
            
            Schedule? schedule = _context.schedule.Find(ticketDto.ScheduleID);
            if (schedule == null)
                return NotFound(new { message = "Couldn't find Schedule by given ID" });

            List<Ticket> tickets = new List<Ticket>();
            foreach (var item in ticketDto.SeatNumber)
            {
                Ticket ticket = new Ticket()
                {
                    PassengerID = ticketDto.PassengerID,
                    ScheduleID = ticketDto.ScheduleID,
                    SeatNumber = item,
                    BookingTime = DateTime.Now
                };

                tickets.Add(ticket);
                _context.ticket.Add(ticket);
            }
            _context.SaveChanges();
            return Ok(new {message = "Created Ticket Successfully", data = tickets});

        }
    }
}
