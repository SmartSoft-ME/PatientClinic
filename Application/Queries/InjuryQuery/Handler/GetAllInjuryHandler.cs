using Domain;
using Mapster;
using Application.IRepositories;
using Shared.Queries;
using Application.DTO;
using Application.Queries.PatientQueries;

namespace Application.Queries.InjuryQueries.Handler
{
    internal class GetAllInjuryHandler : IQueryHandler<GetAllInjuryQuery, List<InjuryDto>>
    {
        public readonly IInjuryRepository IRepository;
        public GetAllInjuryHandler(IInjuryRepository repository)
        {
            this.IRepository = repository;
        }
        public async Task<List<InjuryDto>> Handle(GetAllInjuryQuery querie, CancellationToken cancel)
        {
            var injury = await IRepository.GetAllEAsync(cancel);
            
            return injury.Adapt<List<Injury>, List<InjuryDto>>().ToList();

        }


    }
}
