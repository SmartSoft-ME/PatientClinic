using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommand
{
    public record CreatePatientCommand( string name, string address, int age,List<int> InjuryIds) : ICommand<PatientDto>;
}
