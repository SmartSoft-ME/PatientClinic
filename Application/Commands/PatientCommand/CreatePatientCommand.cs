using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommand
{
    public record CreatePatientCommand(int id, string name, string addresse, int age, List<int> injuriesId) : ICommand<PatientDto>;
}
