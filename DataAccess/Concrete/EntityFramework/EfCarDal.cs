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
                if(filter == null)
                {
                    var result = context.Cars
                    .Include(i => i.Brand)
                    .Include(i => i.Color)
                    .Include(i => i.CarImages)
                    .Select(s => new CarDetailDto
                    {
                        Id = s.Id,
                        BrandName = s.Brand.BrandName,
                        ColorName = s.Color.ColorName,
                        Descriptions = s.Descriptions,
                        DailyPrice = s.DailyPrice,
                        ModelYear = s.ModelYear,
                        ImagePath = s.CarImages.Select(sk => sk.ImagePath).ToList(),
                        FindeksScore =s.FindeksScore

                    }).ToList();
                    return result;
                }
                else
                {
                    var result = context.Cars
                    .Where(filter)
                    .Include(i => i.Brand)
                    .Include(i => i.Color)
                    .Include(i => i.CarImages)
                    .Select(s => new CarDetailDto
                    {
                        Id = s.Id,
                        BrandName = s.Brand.BrandName,
                        ColorName = s.Color.ColorName,
                        Descriptions = s.Descriptions,
                        DailyPrice = s.DailyPrice,
                        ModelYear = s.ModelYear,
                        ImagePath = s.CarImages.Select(sk => sk.ImagePath).ToList(),
                        FindeksScore = s.FindeksScore
                        

                    }).ToList();
                    return result;
                }

            }
        }

        public List<CarDetailDto> GetSingleCarDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = context.Cars
                    .Where(filter)
                    .Include(i => i.Brand)
                    .Include(i => i.Color)
                    .Include(i => i.CarImages)
                    .Select(s => new CarDetailDto
                    {
                        Id = s.Id,
                        BrandName = s.Brand.BrandName,
                        ColorName = s.Color.ColorName,
                        Descriptions = s.Descriptions,
                        DailyPrice = s.DailyPrice,
                        ModelYear = s.ModelYear,
                        ImagePath = s.CarImages.Select(sk => sk.ImagePath).ToList(),
                        FindeksScore = s.FindeksScore

                    }).ToList();
                return result;
            }
        }
    }
}
