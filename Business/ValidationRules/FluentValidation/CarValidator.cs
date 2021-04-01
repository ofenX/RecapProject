using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>

    {
        public CarValidator()
        {
            // Validation rule buraya yazılır
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);


        }
    }
}
