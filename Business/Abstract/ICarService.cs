using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        /// <summary>
        /// Add new Car
        /// </summary>
        /// <param name="car">
        /// Car Entity
        /// </param>
        void AddCar(Car car);
    }
}
