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
        public readonly IInjuryRepository Irepository;
        public GetAllInjuryHandler(IInjuryRepository repository)
        {
            this.Irepository = repository;
        }
        public async Task<List<InjuryDto>> Handle(GetAllInjuryQuery querie, CancellationToken cancel)
        {
            var injury = await Irepository.GetAllEAsync(cancel);
            
            return injury.Adapt<List<Injury>, List<InjuryDto>>().ToList();

        }


    }
}
