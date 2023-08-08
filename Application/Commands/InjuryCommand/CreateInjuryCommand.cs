using Application.DTO;
using Domain;
using MediatR;
using Shared.Commands;

namespace Application.Commands.InjuryCommands
{
    public record CreateInjuryCommand(string Type, string Treatment) : ICommand<InjuryDto>;
}
