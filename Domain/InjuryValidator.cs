using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Domain
{
    public class InjuryValidator: AbstractValidator<Injury>
    {
        public InjuryValidator()
        {
            RuleFor(i=>i.id).NotEmpty();
            RuleFor(i => i.type).NotNull();
            RuleFor(i=>i.treatement).NotEmpty();
            RuleFor(i => i.PatientId).NotEmpty();
        }
    }
}
