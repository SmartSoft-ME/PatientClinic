using Application.Commands.InjuryCommands;
using Application.DTO;
using Application.IRepositories;
using MediatR;
using Shared.Commands;
using Shared;
using Mapster;
using Domain;
using FluentValidation;

namespace Application.Commands.InjuryCommands.Handler
{
    internal class CreateInjuryHandler : ICommandHandler<CreateInjuryCommand, InjuryDto>
    {
        private readonly IInjuryRepository _IRepository;
      
        public CreateInjuryHandler(IInjuryRepository IRepository) { 
            
            _IRepository = IRepository;
          
        }
        public async Task<Response<InjuryDto>> Handle(CreateInjuryCommand command, CancellationToken cancellationToken)
        {
            var (type, treatment,Patientid) = command;
              
          
            var injurie = new Injury(type, treatment,Patientid);
           
           

            var newInjury = await _IRepository.AddAsync(injurie);


            
            return Response.Success(newInjury.Adapt<Injury,InjuryDto>(), "Injury added successfully");
        }
    }
}
