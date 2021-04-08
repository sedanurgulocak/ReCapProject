using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        private readonly ICarService _carService;

        public CustomerManager(ICustomerDal customerDal, ICarService carService)
        {
            _customerDal = customerDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public void AddFindeksScore(int customerId, int carId)
        {
            var score = _carService.CalculateFindeksScore(carId);
            var customer = _customerDal.GetById(c => c.CustomerId == customerId);
            if (customer.FindeksScore <1900)
            {
                var newCustomerScore = customer.FindeksScore + score;
                Update(new Customer { CustomerId = customer.CustomerId, UserId = customer.UserId, CompanyName = customer.CompanyName, FindeksScore = (int)newCustomerScore });

            }

        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.GetById(u => u.CustomerId == id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }

    }
}
