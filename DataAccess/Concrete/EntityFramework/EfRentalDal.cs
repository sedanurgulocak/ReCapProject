using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {

        public List<RentalDetailDto> GetRentalDetailDtos(Expression<Func<Rental, bool>> filter= null)
        {
            using (RentACarContext context= new RentACarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CarId = c.Id,
                                 CarDescription = c.Descriptions,
                                 BrandName = b.BrandName,
                                 CompanyName = cs.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName= u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
        public RentalDetailDto GetRentalDetail(int id)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals.Where(r => r.CarId ==id)
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CarId = c.Id,
                                 CarDescription = c.Descriptions,
                                 BrandName = b.BrandName,
                                 CompanyName = cs.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.SingleOrDefault();

            }
        }
    }
}
