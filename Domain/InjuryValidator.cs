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
            RuleFor(i=>i.Id).NotEmpty();
            RuleFor(i => i.Type).NotNull();
            RuleFor(i=>i.Treatment).NotEmpty();
            
        }
    }
}
