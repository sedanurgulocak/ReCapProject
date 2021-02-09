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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var addedEntity = context.Entry(entity); //capture reference
                addedEntity.State = EntityState.Added; //state what the process is
                context.SaveChanges(); //execution of the transaction
            }
        }

        public void Delete(Color entity)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var deletedEntity = context.Entry(entity); //capture reference
                deletedEntity.State = EntityState.Deleted; //state what the process is
                context.SaveChanges(); //execution of the transaction
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public Color GetById(Expression<Func<Color, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);

            }
        }

        public void Update(Color entity)
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
