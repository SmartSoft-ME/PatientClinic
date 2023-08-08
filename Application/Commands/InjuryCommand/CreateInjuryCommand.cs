using Application.DTO;
using Domain;
using MediatR;
using Shared.Commands;

namespace Application.Commands.InjuryCommands
{
    public record CreateInjuryCommand(string type, string treatment,int patientId) : ICommand<InjuryDto>;
}
