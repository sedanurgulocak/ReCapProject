using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    /// <summary>
    /// This interface includes custom query for Car Entity
    /// </summary>
    public interface ICarDal
    {
        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns>
        /// List of Car
        /// </returns>
        List<Car> GetAll();

        /// <summary>
        /// Get Cars with CarId
        /// </summary>
        /// <param name="carId">
        /// PK of Car Entity
        /// </param>
        /// <returns>
        /// Car Entity
        /// </returns>
        Car GetById(int carId);

        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="car">
        /// Car Entity
        /// </param>
        void Add(Car car);

        /// <summary>
        /// Update Car
        /// </summary>
        /// <param name="car">
        /// Car Entity
        /// </param>
        void Update(Car car);

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="car">
        /// Car Entity
        /// </param>
        void Delete(Car car);

    }
}
