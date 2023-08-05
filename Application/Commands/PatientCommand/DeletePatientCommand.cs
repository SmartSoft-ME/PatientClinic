using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommands
{
    public record DeletePatientCommand(int id) : ICommand<Unit>;
}
