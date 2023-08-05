using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;
using Application.Commands.PatientCommands;

namespace Application.Commands.PatientCommand.Handler
{
    internal class UpdatePatientHandler: ICommandHandler<UpdatePatientCommand,PatientDto>
    {
        private readonly IInjuryRepository _Irepository;
        private readonly IPatientRepository _patientRepository;
        public UpdatePatientHandler(IInjuryRepository Irepository, IPatientRepository Prepository)
        {
            _Irepository = Irepository;
            _patientRepository = Prepository;
        }
        public async Task<Response<PatientDto>> Handle(UpdatePatientCommand UPD, CancellationToken cancel) {
            var (id, name, address, age, injuryid) = UPD;
            var patient = await _patientRepository.GetByIdAsync(id, cancel);
            if (injuryid != null)
            {
                var newInjury = new List<Injury>();
                 foreach(var InjuriesId in injuryid) 
                    newInjury.Add(await _Irepository.GetByIdAsync(InjuriesId, cancel));
                    patient.UpdateI(newInjury);
            }
            patient.update(name, address, age);
            var UpdatedPatient=await _patientRepository.UpdateAsync(patient);
            var setter = TypeAdapterConfig<Injury, InjuryDto>.NewConfig()
                .Map(dest => dest.paids, src => src.Pa.Select(i => i.Id)).MaxDepth(2);
            return Response.Success(UpdatedPatient.Adapt<Patient, PatientDto>(setter.Config), "PatientUpdated" + UpdatedPatient.Id);
        }
    }
}
