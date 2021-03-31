using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber);
        IDataResult<CreditCard> GetById(int id);
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        IResult Update(CreditCard creditCard);

        IDataResult<bool> Pay(PayDto pay);
    }
}
