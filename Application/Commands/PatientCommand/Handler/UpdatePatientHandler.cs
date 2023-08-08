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
        private readonly IInjuryRepository _IRepository;
        private readonly IPatientRepository _patientRepository;
        public UpdatePatientHandler(IInjuryRepository IRepository, IPatientRepository PRepository)
        {
            _IRepository = IRepository;
            _patientRepository = PRepository;
        }
        public async Task<Response<PatientDto>> Handle(UpdatePatientCommand UPD, CancellationToken cancel) {
            var (id, name, address, age) = UPD;
            var patient = await _patientRepository.GetByIdAsync(id, cancel);
          
            patient.update(name, address, age);
            var UpdatedPatient=await _patientRepository.UpdateAsync(patient);
            
            return Response.Success(UpdatedPatient.Adapt<Patient, PatientDto>(), "PatientUpdated" + UpdatedPatient.Id);
        }
    }
}
