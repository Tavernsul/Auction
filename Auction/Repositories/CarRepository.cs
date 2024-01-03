using System;
using System.Collections.Generic;
using System.Linq;
using Auction.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auction.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        void AddCar(Car car);
        void UpdateCar(Car updatedCar);
        void DeleteCar(int id);
    }

    public class CarRepository : ICarRepository
    {
        private readonly AuctionDbContext _context;

        public CarRepository(AuctionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.Find(id);
        }

        public void AddCar(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void UpdateCar(Car updatedCar)
        {
            _context.Entry(updatedCar).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var carToRemove = _context.Cars.FirstOrDefault(c => c.Id == id);
            if (carToRemove != null)
            {
                _context.Cars.Remove(carToRemove);
                _context.SaveChanges();
            }
        }
    }
}
