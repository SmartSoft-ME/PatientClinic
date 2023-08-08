using FluentValidation;

namespace Application.Commands.PatientCommand
{
    public class CreatePatientValidator:AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator() 
        {
            RuleFor(p => p.address).NotEmpty().NotNull();
            RuleFor(p => p.name).NotEmpty().NotNull().Length(0, 20);
            RuleFor(p => p.age).NotNull();
        }
    }
}
