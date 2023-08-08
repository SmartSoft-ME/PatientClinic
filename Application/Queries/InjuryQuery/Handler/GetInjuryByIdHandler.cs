using Domain;
using Mapster;
using Application.IRepositories;
using Shared.Queries;
using Application.DTO;
using Application.Queries.PatientQueries;

namespace Application.Queries.InjuryQueries.Handler
{
    internal class GetInjuryByIdHandler: IQueryHandler<GetInjuryByIdQuery, InjuryDto>
    {
        public readonly IInjuryRepository IRepository;
        public GetInjuryByIdHandler(IInjuryRepository repository)
        {
            this.IRepository = repository;
        }
        public async Task<InjuryDto> Handle(GetInjuryByIdQuery query, CancellationToken cancel)
        {
            var injury = await IRepository.GetByIdAsync(query.id, cancel);
           
            return injury.Adapt<Injury, InjuryDto>();



        }

    }
}
