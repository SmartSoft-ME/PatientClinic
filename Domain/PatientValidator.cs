using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Domain
{
    public class PatientValidator: AbstractValidator<Patient>
    {
        public PatientValidator() 
        {
            RuleFor(p => p.Name).NotEmpty().MaximumLength(20);
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Address).NotEmpty().Matches("street");
            RuleFor(p => p.Age).NotNull();
        }
    }
}
