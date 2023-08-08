using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommand
{
    public record PatientInjuryCommand(int id,string type,string treatment) : ICommand<PatientDto>;

}
