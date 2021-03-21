﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {
                new Car {Id=1, BrandId=1, ColorId=0, DailyPrice=100, Descriptions="Volvo", ModelYear="2020"},
                new Car{Id=2, BrandId=1, ColorId=0, DailyPrice=200, Descriptions="Volvo", ModelYear="2021"}
            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }


        public List<Car> GetById(int carId)
        {
            return _car.Where(c => c.Id == carId).ToList();
        }

        
        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetSingleCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        List<CarDetailDto> ICarDal.GetSingleCarDetail(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
