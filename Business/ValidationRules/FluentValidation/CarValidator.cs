using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            //kuralları yaz
            //car.Name.Length
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1000).When(c => c.ModelYear == 2019);

            //sample custom method
            //RuleFor(c => c.Name).Must(StartWithA).WithMessage("Arac adi A ile baslamalı");//custom
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
