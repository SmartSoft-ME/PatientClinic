using Application.Commands.InjuryCommands;
using FluentValidation;

namespace Application.Commands.InjuryCommand
{
    public class DeleteInjuryValidator:AbstractValidator<DeleteInjuryCommand>
    {
        public DeleteInjuryValidator() 
        {
            RuleFor(i => i.id).NotEmpty();
        }
    }
}
