using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommands
{
    public record UpdatePatientCommand(int id, string name, string addresse, int age, List<int> injuryID) : ICommand<PatientDto>;
}
