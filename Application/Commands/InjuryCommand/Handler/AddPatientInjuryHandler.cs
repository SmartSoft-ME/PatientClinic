using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;


namespace Application.Commands.InjuryCommand.Handler
{
    public class AddPatientInjuryHandler: ICommandHandler<AddPatientInjuryCommand,InjuryDto>
    {
        private readonly IInjuryRepository _Repository;
        private readonly IPatientRepository _patientRepository;
        public AddPatientInjuryHandler(IInjuryRepository Repository, IPatientRepository PRepository)
        {
            _Repository = Repository;
            _patientRepository = PRepository;
        }
        public async Task<Response<InjuryDto>> Handle(AddPatientInjuryCommand command, CancellationToken cancel)
        {
            var (id, name, address, age) = command;
            var injury = await _Repository.AddPatient(id, name, address, age);
            return  Response.Success(injury.Adapt<Injury,InjuryDto>(),"Patient Added To Injury Table");

        }
    }
}
