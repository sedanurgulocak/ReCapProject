using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        /// <summary>
        /// Add new Car
        /// </summary>
        /// <param name="car">
        /// Car Entity
        /// </param>
        public void AddCar(Car car)
        {
            _carDal.Add(car);
        }

        public List<Car> GetAll()
        {
            // Business Logic
            return _carDal.GetAll();
        }
    }
}
