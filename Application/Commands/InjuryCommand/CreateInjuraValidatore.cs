using Application.Commands.InjuryCommands;
using FluentValidation;

namespace Application.Commands.InjuryCommand
{
    public class CreateInjuraValidatore:AbstractValidator<CreateInjuryCommand>
    {
        public CreateInjuraValidatore() 
        {
            RuleFor(i => i.type).NotEmpty().NotNull();
            RuleFor(i => i.treatement).NotEmpty().NotNull();
        }
    }
}
