using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;
using Application.Commands.PatientCommands;
using System.Threading;

namespace Application.Commands.PatientCommand.Handler
{
    internal class CreatePatientHandler:ICommandHandler<CreatePatientCommand,PatientDto>
    {
        private readonly IInjuryRepository _Irepository;
        private readonly IPatientRepository _patientRepository;
        public CreatePatientHandler(IInjuryRepository Irepository, IPatientRepository Prepository)
        {
            _Irepository = Irepository;
            _patientRepository = Prepository;
        }
        public async Task<Response<PatientDto>> Handle(CreatePatientCommand CPC,CancellationToken cancel)
        {
            var (id, name, addresse, age, injuriesId) = CPC;
           
            var injury = new List<Injury>();
            foreach (var injuryids in injuriesId)
            {
                injury.Add(await _Irepository.GetByIdAsync(injuryids, cancel));
            }

           

            var patient = new Patient(name,addresse,age);
            patient.AddI(injury);
            var newpa = await _patientRepository.AddAsync(patient);

            var setter = TypeAdapterConfig<Injury, InjuryDto>.NewConfig()
                .Map(dest => dest.paids, src => src.Pa.Select(i => i.Id)).MaxDepth(2);
            return Response.Success(newpa.Adapt<Patient, PatientDto>(setter.Config), "Created patient " + newpa.Id);
        }
    }
}
