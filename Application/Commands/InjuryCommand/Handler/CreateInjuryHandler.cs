using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;

namespace Application.Commands.InjuryCommands.Handler
{
    internal class CreateInjuryHandler : ICommandHandler<CreateInjuryCommand, InjuryDto>
    {
        private readonly IInjuryRepository _Irepository;
        private readonly IPatientRepository _patientRepository;
        public CreateInjuryHandler(IInjuryRepository Irepository, IPatientRepository Prepository)
        {
            _Irepository = Irepository;
            _patientRepository = Prepository;
        }
        public async Task<Response<InjuryDto>> Handle(CreateInjuryCommand CIC, CancellationToken cancellationToken)
        {
            var (type, treatement, paIds) = CIC;
            
            var patient = new List<Patient>();
            foreach (var patientids in paIds)
            {
                patient.Add(await _patientRepository.GetByIdAsync(patientids, cancellationToken));
            }

            
            var injurie = new Injury(type, treatement);
            injurie.AddPS(patient);

            var newinjury = await _Irepository.AddAsync(injurie);

            var setter = TypeAdapterConfig<Injury, InjuryDto>.NewConfig()
                .Map(dest => dest.paids, src => src.Pa.Select(i => i.Id)).MaxDepth(2);
            return Response.Success(newinjury.Adapt<Injury, InjuryDto>(setter.Config), "Created post " + newinjury.type);
        }
    }
}
