using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<IFormFile>
    {
        public CarImageValidator()
        {
            RuleFor(r => r.FileName).NotEmpty().NotNull();
        }
    }
}
