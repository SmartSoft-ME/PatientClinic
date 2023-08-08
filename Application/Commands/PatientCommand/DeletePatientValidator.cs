using Application.Commands.PatientCommands;
using FluentValidation;
namespace Application.Commands.PatientCommand
{
    public class DeletePatientValidator: AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientValidator() 
        {
            RuleFor(p=>p.id).NotEmpty();
        }
    }
}
