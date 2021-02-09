using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (RentACarContext context= new RentACarContext())
            {
                var addedEntity = context.Entry(entity); //capture reference
                addedEntity.State = EntityState.Added; //state what the process is
                context.SaveChanges(); //execution of the transaction
            }
        }

        public void Delete(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity); //capture reference
                deletedEntity.State = EntityState.Deleted; //state what the process is
                context.SaveChanges(); //execution of the transaction
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            using (RentACarContext context=new RentACarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);

            }
        }

        public void Update(Car entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var updatedEntity = context.Entry(entity); //capture reference
                updatedEntity.State = EntityState.Modified; //state what the process is
                context.SaveChanges(); //execution of the transaction
            }
        }
    }
}
