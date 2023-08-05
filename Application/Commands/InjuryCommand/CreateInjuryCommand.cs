using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.InjuryCommands
{
    public record CreateInjuryCommand(string type, string treatement, List<int> paIds) : ICommand<InjuryDto>;
}
