using Application.Commands.InjuryCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.InjuryCommand
{
    public class UpdateInjuryValidator:AbstractValidator<UpdateInjuryCommand>
    {
        public UpdateInjuryValidator() 
        {
            RuleFor(i => i.id).NotEmpty();
            RuleFor(i => i.type).NotEmpty().NotNull();
            RuleFor(i => i.treatement).NotEmpty().NotNull();
        }
    }
}
