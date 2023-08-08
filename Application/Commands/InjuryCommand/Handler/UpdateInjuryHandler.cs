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
    internal class UpdateInjuryHandler:ICommandHandler<UpdateInjuryCommand,InjuryDto>
    {
        private readonly IInjuryRepository _Irepository;
        private readonly IPatientRepository _patientRepository;
        public UpdateInjuryHandler(IInjuryRepository Irepository, IPatientRepository Prepository)
        {
            _Irepository = Irepository;
            _patientRepository = Prepository;
        }
        public async Task<Response<InjuryDto>> Handle(UpdateInjuryCommand UIC,CancellationToken cancel)
        {
            var (id, type, treatement) = UIC;
            var injury = await _Irepository.GetByIdAsync(id, cancel);
            
                injury.UpdateI(type, treatement);
                var UpdatedInjury = await _Irepository.UpdateAsync(injury);
               
                return Response.Success(UpdatedInjury.Adapt<Injury, InjuryDto>(),"InjuryUpdated"+UpdatedInjury.treatement);
            
        }
    }
}
