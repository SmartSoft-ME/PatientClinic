using Domain;
using Mapster;
using Application.IRepositories;
using Shared.Queries;
using Application.DTO;


namespace Application.Queries.PatientQueries.Handler
{
    internal class GetAllPatientHandler: IQueryHandler<GetAllPatientQuerie,List<PatientDto>>
    {
        public readonly IPatientRepository PRepository;
        public GetAllPatientHandler(IPatientRepository pRepository)
        {
            this.PRepository = pRepository;
        }
        public async Task<List<PatientDto>> Handle(GetAllPatientQuerie querie,CancellationToken cancel)
        {
            var patient = await PRepository.GetAllEAsync(cancel);

            return patient.Adapt<List<Patient>, List<PatientDto>>().ToList();

        }
    }
}
