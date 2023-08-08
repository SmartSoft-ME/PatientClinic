using Application.Commands.InjuryCommands;
using FluentValidation;

namespace Application.Commands.InjuryCommand
{
    public class CreateInjuraValidatore:AbstractValidator<CreateInjuryCommand>
    {
        public CreateInjuraValidatore() 
        {
            RuleFor(i => i.Type).NotEmpty().NotNull();
            RuleFor(i => i.Treatment).NotEmpty().NotNull();
        }
    }
}
