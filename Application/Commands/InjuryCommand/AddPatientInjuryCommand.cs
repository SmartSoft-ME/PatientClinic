using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.InjuryCommand
{
    public record AddPatientInjuryCommand(int InjuryId,string Name,string Address,int Age):ICommand<InjuryDto>;
}
