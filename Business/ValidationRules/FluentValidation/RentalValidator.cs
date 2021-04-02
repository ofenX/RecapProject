using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {

        public RentalValidator()
        {
            // Validation rule buraya yazılır
            RuleFor(c => c.Rentdate).NotEmpty();



        }
    }
}
