using esemkarailways.Data;
using esemkarailways.Dto;
using esemkarailways.Models;
using Microsoft.AspNetCore.Mvc;

namespace esemkarailways.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class StationController : Controller
    {
        DataContext _context;
        public StationController(DataContext _context) => this._context = _context;

        [HttpGet("Station")]
        public IActionResult GetStation()
        {
            var stations = _context.station.ToList();

            return Ok(stations);
        }

        [HttpGet("Station/{id}")]
        public IActionResult GetStations(int id)
        {
            Station? station = _context.station.Find(id);
            if (station == null)
                return NotFound(new { message = "Couldn't find Station with given id" });

            return Ok(station);
        }

        [HttpPost("Station")]
        public IActionResult PostStation(StationDto stationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Station station = new Station()
            {
                StationName = stationDto.StationName,
                Location = stationDto.Location
            };

            _context.station.Add(station);
            _context.SaveChanges();
            return Ok(new {message = "Created Station Data Successfully", data = station});

        }

        [HttpPut("Station/{id}")]
        public IActionResult PutStation(int id, [FromBody]StationDto stationDto)
        {
            Station? station = _context.station.Find(id);
            if (station == null)
                return NotFound(new { message = "Couldn't find Station with given id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            station.StationName = stationDto.StationName;
            station.Location = stationDto.Location;

            _context.station.Update(station);
            _context.SaveChanges();
            return Ok(new {message = "Updated Station Data Successfully", data = station});
        }

        [HttpDelete("Station/{id}")]
        public IActionResult DeleteStation(int id)
        {
            Station? station = _context.station.Find(id);
            if (station == null)
                return NotFound(new { message = "Couldn't find Station with given id" });

            _context.station.Remove(station);
            _context.SaveChanges();
            return Ok(new {message = "Deleting Station Data Successfully", data = station});
        }

    }
}
