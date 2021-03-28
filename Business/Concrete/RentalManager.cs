using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            if (IsRentCheck(rental))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
                return new ErrorResult(Messages.RentalAddedError);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.RentalId == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos(r => r.CarId == carId));
        }

        public bool IsRentCheck(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (r.RentDate.Date == rental.RentDate.Date || r.ReturnDate.Date >= rental.RentDate));
            if (result.Count > 0)
            {
                return false;
            }
            return true;
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId);
            var updatedRental = result.LastOrDefault();
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdatedReturnDateError);
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdatedReturnDate);
        }
    }
}
