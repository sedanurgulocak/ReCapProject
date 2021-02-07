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
        List<Car> GetAll();
        List<Car> GetById(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
