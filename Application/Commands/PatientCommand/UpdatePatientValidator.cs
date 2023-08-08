using Application.Commands.PatientCommands;
using FluentValidation;

namespace Application.Commands.PatientCommand
{
   public class UpdatePatientValidator :AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator() 
        {
            RuleFor(p => p.id).NotEmpty();
            RuleFor(p => p.address).NotEmpty().NotNull();
            RuleFor(p => p.name).NotEmpty().NotNull().Length(0, 20);
            RuleFor(p => p.age).NotNull();
        }
    }
}
