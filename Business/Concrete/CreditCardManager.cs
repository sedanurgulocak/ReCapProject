using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;
        private readonly ICarService carService;
        private readonly IRentalService rentalService;

        public CreditCardManager(ICreditCardDal creditCardDal, ICarService carService, IRentalService rentalService)
        {
            _creditCardDal = creditCardDal;
            this.carService = carService;
            this.rentalService = rentalService;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<bool> Pay(PayDto pay)
        {
            if(rentalService.IsRentCheck(new Rental {CarId=pay.CarId, RentDate=pay.RentDate, ReturnDate=pay.ReturnDate }))
            {
                var car = carService.GetById(pay.CarId);
                var day = pay.ReturnDate - pay.RentDate;
                var totlDays = day.TotalDays == 0 ? 1 : day.TotalDays;
                if (((decimal)totlDays * car.Data.DailyPrice) != pay.AmountPay)
                {
                    return new SuccessDataResult<bool>(false);
                }
                Add(new CreditCard { CardNumber = pay.CardNumber, CVV = pay.CVV, ExpirationDate = pay.ExpirationDate, NameOnTheCard = pay.NameOnTheCard });
                return new SuccessDataResult<bool>(true);
            }
            return new ErrorDataResult<bool>(false);
            
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }
    }
}
