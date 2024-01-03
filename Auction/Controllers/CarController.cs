using Microsoft.AspNetCore.Mvc;
using Auction.Repositories;
using Auction.Entities;

namespace Auction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public IActionResult GetAllCars()
        {
            var cars = _carRepository.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarById(int id)
        {
            var car = _carRepository.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            _carRepository.AddCar(car);
            return CreatedAtAction(nameof(GetCarById), car);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Car updatedCar)
        {
            var existingCar = _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            updatedCar.Id = id; // Ensure the ID is set correctly
            _carRepository.UpdateCar(updatedCar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCar = _carRepository.GetCarById(id);
            if (existingCar == null)
            {
                return NotFound();
            }

            _carRepository.DeleteCar(id);
            return NoContent();
        }
    }
}
