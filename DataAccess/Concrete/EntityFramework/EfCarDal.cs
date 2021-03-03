using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto { 
                                 Id = c.Id, 
                                 BrandName = b.BrandName, 
                                 ColorName = cl.ColorName, 
                                 Descriptions = c.Descriptions, 
                                 DailyPrice=c.DailyPrice,
                                 CarImageDate=ci.CarImageDate,
                                 ImagePath=ci.ImagePath
                             
                             };
                return result.ToList();

            }
        }
    }
}
