using Domain;
using Mapster;
using Application.IRepositories;
using Shared.Queries;
using Application.DTO;

namespace Application.Queries.PatientQueries.Handler
{
    internal class GetPatientByIdHandler: IQueryHandler<GetPatientByIdQueries,PatientDto>
    {
        public readonly IPatientRepository PRepository;
        public GetPatientByIdHandler(IPatientRepository pRepository)
        {
            this.PRepository = pRepository;
        }
        public async Task<PatientDto> Handle(GetPatientByIdQueries query,CancellationToken cancel)
        {
            var patient=await PRepository.GetByIdAsync(query.id,cancel);
            var setter = TypeAdapterConfig<Patient, PatientDto>.NewConfig()
                 .Map(dest => dest.Injury, src => src.Injuries.Select(i => i.Id)).MaxDepth(2);
            return patient.Adapt<Patient, PatientDto>(setter.Config);
        }
    }
}
