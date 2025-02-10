using esemkarailways.Data;
using esemkarailways.Dto;
using esemkarailways.Models;
using Microsoft.AspNetCore.Mvc;

namespace esemkarailways.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TrainController : Controller
    {
        DataContext _context;
        public TrainController(DataContext _context) => this._context = _context;

        [HttpGet("Train")]
        public IActionResult GetTrain()
        {
            var trains = _context.train.ToList();

            return Ok(trains);
        }

        [HttpGet("Train/{id}")]
        public IActionResult GetTrains(int id)
        {
            Train? train = _context.train.Find(id);
            if (train == null)
                return NotFound(new { message = "Couldn't find train with given id" });

            return Ok(train);
        }

        [HttpPost("Train")]
        public IActionResult PostTrain(TrainDto trainDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (trainDto.Type != "Express" && trainDto.Type != "Local")
                return BadRequest(new { message = "The type must be either 'Express' or 'Local'" } );

            Train train = new Train()
            {
                TrainName = trainDto.TrainName,
                Capacity = trainDto.Capacity,
                Type = trainDto.Type 
            };

            _context.train.Add(train);
            _context.SaveChanges();
            return Ok(new { message = "Created Station Data Successfully", data = train });

        }

        [HttpPut("Train/{id}")]
        public IActionResult PutTrain(int id, [FromBody] TrainDto trainDto )
        {
            Train? train = _context.train.Find(id);
            if (train == null)
                return NotFound(new { message = "Couldn't find Train with given id" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (trainDto.Type != "Express" && trainDto.Type != "Local")
                return BadRequest(new { message = "The type must be either 'Express' or 'Local'" });

            train.TrainName = trainDto.TrainName;
            train.Capacity = trainDto.Capacity;
            train.Type = trainDto.Type;

            _context.train.Update(train);
            _context.SaveChanges();
            return Ok(new { message = "Updated Traihn Data Successfully", data = train });
        }

        [HttpDelete("Train/{id}")]
        public IActionResult DeleteTrain(int id)
        {
            Train? train = _context.train.Find(id);
            if (train == null)
                return NotFound(new { message = "Couldn't find Train with given id" });

            _context.train.Remove(train);
            _context.SaveChanges();
            return Ok(new { message = "Deleting Train Data Successfully", data = train });


        }

    }
}
