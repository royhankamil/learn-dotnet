using esemkarailways.Data;
using esemkarailways.Dto;
using esemkarailways.Models;
using Microsoft.AspNetCore.Mvc;

namespace esemkarailways.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PassengerController : Controller
    {
        public DataContext _context;
        public PassengerController(DataContext _context)
        {
            this._context = _context;
        }

        [HttpGet("Passenger")]
        public IActionResult GetPassenegr()
        {
            var passenger = _context.passenger.ToList();
            return Ok(passenger);
        }

        [HttpGet("Passenger/{id}")]
        public IActionResult GetPassengerbyId(int id)
        {
            Passenger? passenger = _context.passenger.Find(id);

            if (passenger == null)
                return NotFound(new { message = "Couldn't find passenger by given id" });

            return Ok(passenger);
        }

        [HttpPost("Passenger")]
        public IActionResult PostPassenger(PassengerDto passengerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Passenger validationEmail = _context.passenger.FirstOrDefault(u => u.Email == passengerDto.Email);
            if (validationEmail != null)
                return Conflict(new { message = $"{passengerDto.Email} has already exist" });

            Passenger validationPhoneNum = _context.passenger.FirstOrDefault(u => u.PhoneNumber == passengerDto.Phone);
            if (validationPhoneNum != null)
                return Conflict(new { message = $"{passengerDto.Phone} has already exist" });

            Passenger passenger = new Passenger()
            {
                FirstName = passengerDto.FirstName,
                LastName = passengerDto.LastName,
                Email = passengerDto.Email,
                PhoneNumber = passengerDto.Phone
            };


            _context.passenger.Add(passenger);
            _context.SaveChanges();
            return Ok(new { message = "Data Created Successfully", data = passenger });

        }

        [HttpPut("Passenger/{id}")]
        public IActionResult PutPassenger(int id, [FromBody] PassengerDto passengerDto)
        {
            Passenger? passenger = _context.passenger.Find(id);

            if (passenger == null)
                return NotFound(new { message = "Couldn't find passenger by given id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Passenger validationEmail = _context.passenger.FirstOrDefault(u => u.Email == passengerDto.Email);
            if (validationEmail != null && validationEmail.PassengerID != id)
                return Conflict(new { message = $"{passengerDto.Email} has already exist" });

            Passenger validationPhoneNum = _context.passenger.FirstOrDefault(u => u.PhoneNumber == passengerDto.Phone);
            if (validationPhoneNum != null && validationEmail.PassengerID != id)
                return Conflict(new { message = $"{passengerDto.Phone} has already exist" });

            passenger.FirstName = passengerDto.FirstName;
            passenger.LastName = passengerDto.LastName;
            passenger.Email = passengerDto.Email;
            passenger.PhoneNumber = passengerDto.Phone;

            _context.passenger.Update(passenger);
            _context.SaveChanges();
            return Ok(new { message = "Data Changed Successfully", data = passenger });
        }

        [HttpDelete("Passenger/{id}")]
        public IActionResult DeletePassenger(int id)
        {
            Passenger? passenger = _context.passenger.Find(id);

            if (passenger == null)
                return NotFound(new { message = "Couldn't find passenger by given id" });

            _context.passenger.Remove(passenger);
            _context.SaveChanges();
            return Ok(new { message = "Deleting data successfully", data = passenger});
        }
        
    }
}
