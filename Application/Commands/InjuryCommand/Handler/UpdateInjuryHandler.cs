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
    public class UpdateInjuryHandler:ICommandHandler<UpdateInjuryCommand,InjuryDto>
    {
        private readonly IInjuryRepository _Repository;
        private readonly IPatientRepository _patientRepository;
        public UpdateInjuryHandler(IInjuryRepository Repository, IPatientRepository PRepository)
        {
            _Repository = Repository;
            _patientRepository = PRepository;
        }
        public async Task<Response<InjuryDto>> Handle(UpdateInjuryCommand command,CancellationToken cancel)

        {
            var (id, type, treatment) = command;
            var injury = await _Repository.GetByIdAsync(id, cancel);
            
                injury.UpdateInjury(type, treatment);
                var UpdatedInjury = await _Repository.UpdateAsync(injury);
               
                return Response.Success(UpdatedInjury.Adapt<Injury, InjuryDto>(),"InjuryUpdated"+UpdatedInjury.Treatment);
            
        }
    }
}
