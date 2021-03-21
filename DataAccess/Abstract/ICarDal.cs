using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    /// <summary>
    /// This interface includes custom query for Car Entity
    /// </summary>
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailDtos(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetSingleCarDetail(Expression<Func<Car, bool>> filter = null);
    }
}
