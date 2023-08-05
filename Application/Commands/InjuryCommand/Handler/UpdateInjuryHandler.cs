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
            var (id, type, treatement, patientids) = UIC;
            var injury = await _Irepository.GetByIdAsync(id, cancel);
            if (patientids is not null)
            {
                var NewPa = new List<Patient>();
                foreach (var patientid in patientids)
                {
                    NewPa.Add(await _patientRepository.GetByIdAsync(patientid, cancel));
                    injury.UpdatePatient(NewPa);
                }
            }
                injury.UpdateI(type, treatement);
                var UpdatedInjury = await _Irepository.UpdateAsync(injury);
                var setter = TypeAdapterConfig<Injury, InjuryDto>.NewConfig()
                 .Map(dest => dest.paids, src => src.Pa.Select(i => i.Id)).MaxDepth(2);
                return Response.Success(UpdatedInjury.Adapt<Injury, InjuryDto>(setter.Config),"InjuryUpdated"+UpdatedInjury.treatement);
            
        }
    }
}
