using esemkarailways.Data;
using esemkarailways.Dto;
using esemkarailways.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace esemkarailways.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ScheduleController : Controller
    {
        DataContext _context; 
        public ScheduleController(DataContext _context) => this._context = _context;

        [HttpGet("Schedule")]
        public IActionResult GetSChedule()
        {
            var passengers = _context.schedule
                .Include(i => i.ArrivalStation)
                .Include(i => i.DepartureStation)
                .Include(i => i.Train)
                .Select(i=> new
                {
                    i.ScheduleID,
                    i.TrainID,
                    i.DepartureStationID,
                    i.ArrivalStationID,
                    i.DepartureTime,
                    i.ArrivalTime,
                    ArrivalStationName = i.ArrivalStation.StationName,
                    ArrivalLocation = i.ArrivalStation.Location,
                    DeparturetationName = i.DepartureStation.StationName,
                    DepartureLocation = i.DepartureStation.Location,
                    i.Train.TrainName,
                    i.Train.Capacity,
                    i.Train.Type
                }).ToList();
            return Ok(passengers);
        }

        [HttpGet("Schedule/{id}")]
        public IActionResult GetScheduleById(int id)
        {
            var schedule = _context.schedule
                .Include(i => i.ArrivalStation)
                .Include(i => i.DepartureStation)
                .Include(i => i.Train).Where(i=> i.ScheduleID == id)
                .Select(i => new
                {
                    i.ScheduleID,
                    i.TrainID,
                    i.DepartureStationID,
                    i.ArrivalStationID,
                    i.DepartureTime,
                    i.ArrivalTime,
                    ArrivalStationName = i.ArrivalStation.StationName,
                    ArrivalLocation = i.ArrivalStation.Location,
                    DeparturetationName = i.DepartureStation.StationName,
                    DepartureLocation = i.DepartureStation.Location,
                    i.Train.TrainName,
                    i.Train.Capacity,
                    i.Train.Type
                }).ToList();

            if (schedule.Count == 0)
                return NotFound(new { message = "Couldn't find schedule by given id" });

            return Ok(schedule);
        }

        [HttpPost("Schedule")]
        public IActionResult PostSchedule(ScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Train? train = _context.train.FirstOrDefault(t => t.TrainID == scheduleDto.TrainID);
            if (train == default)
                return NotFound("Couldn't find train by given TrainID");
                    
            Station? departure = _context.station.FirstOrDefault(t => t.StationID == scheduleDto.DepartureStationID);
            if (departure == default)
                return NotFound("Couldn't find departure station by given DepartureStationID");
            
            Station? arrival = _context.station.FirstOrDefault(t => t.StationID == scheduleDto.ArrivalStationID);
            if (arrival == default)
                return NotFound("Couldn't find arrival station by given ArrivalStationID");

            if (scheduleDto.DepartureTime >= scheduleDto.ArrivalTime)
                return BadRequest(new { message = "schedules with DepartureTime before ArriveTime." });

            if (scheduleDto.DepartureTime.Date != scheduleDto.ArrivalTime.Date)
                return BadRequest(new { message = "The DepartureTime must be on the same day as ArrivalTime." });

            Schedule schedule = new Schedule()
            {
                TrainID = scheduleDto.TrainID,
                DepartureStationID = scheduleDto.DepartureStationID,
                ArrivalStationID = scheduleDto.ArrivalStationID,
                DepartureTime = scheduleDto.DepartureTime,
                ArrivalTime = scheduleDto.ArrivalTime
             };

            _context.schedule.Add(schedule);
            _context.SaveChanges();
            return Ok(new { message = "Schedule Created Successfully", data = schedule });
                
        }

        [HttpPut("Schedule/{id}")]
        public IActionResult PutSchedule(int id, [FromBody]ScheduleDto scheduleDto)
        {
            Schedule? schedule = _context.schedule.Find(id);

            if (schedule == null)
                return NotFound(new { message = "Couldn't find schedule by given id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Station? departure = _context.station.FirstOrDefault(t => t.StationID == scheduleDto.DepartureStationID);
            if (departure == default)
                return NotFound("Couldn't find departure station by given DepartureStationID");

            Station? arrival = _context.station.FirstOrDefault(t => t.StationID == scheduleDto.ArrivalStationID);
            if (arrival == default)
                return NotFound("Couldn't find arrival station by given ArrivalStationID");

            if (scheduleDto.DepartureTime >= scheduleDto.ArrivalTime)
                return BadRequest(new { message = "schedules with DepartureTime before ArriveTime." });

            if (scheduleDto.DepartureTime.Date != scheduleDto.ArrivalTime.Date)
                return BadRequest(new { message = "The DepartureTime must be on the same day as ArrivalTime." });

            schedule.TrainID = scheduleDto.TrainID;
            schedule.DepartureStationID = scheduleDto.DepartureStationID;
            schedule.ArrivalStationID = scheduleDto.ArrivalStationID;
            schedule.DepartureTime = scheduleDto.DepartureTime;
            schedule.ArrivalTime = scheduleDto.ArrivalTime;

            _context.schedule.Update(schedule);
            _context.SaveChanges();
            return Ok(new { message = "Update Schedule successfully", data = schedule });


        }

        [HttpDelete("Schedule/{id}")]
        public IActionResult DeleteSchedule(int id)
        {
            Schedule? schedule = _context.schedule.Find(id);

            if (schedule == null)
                return NotFound(new { message = "Couldn't find schedule by given id" });

            _context.schedule.Remove(schedule);
            _context.SaveChanges();
            return Ok(new { message = "Deleting Schedule Successfully", data = schedule });
        }

    }
}
