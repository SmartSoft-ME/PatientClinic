using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommands
{
    public record UpdatePatientCommand(int id, string name, string address, int age) : ICommand<PatientDto>;
}
