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
        public readonly IInjuryRepository Irepository;
        public GetInjuryByIdHandler(IInjuryRepository repository)
        {
            this.Irepository = repository;
        }
        public async Task<InjuryDto> Handle(GetInjuryByIdQuery querie, CancellationToken cancel)
        {
            var injury = await Irepository.GetByIdAsync(querie.id, cancel);
            var setter = TypeAdapterConfig<Injury, InjuryDto>.NewConfig()
                 .Map(dest => dest.paids, src => src.Pa.Select(p => p.Id)).MaxDepth(2);
            return injury.Adapt<Injury, InjuryDto>(setter.Config);



        }

    }
}
