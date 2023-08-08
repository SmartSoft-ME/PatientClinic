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
        private readonly IInjuryRepository _Irepository;
        private readonly IValidator<Injury> _validator;
        public CreateInjuryHandler(IInjuryRepository Irepository,IValidator<Injury> validator)
        {
            _validator = validator;
            _Irepository = Irepository;
           
        }
        public async Task<Response<InjuryDto>> Handle(CreateInjuryCommand CIC, CancellationToken cancellationToken)
        {
            var (type, treatement) = CIC;
            
           
            
          

            
            var injurie = new Injury(type, treatement);
            var validation= await _validator.ValidateAsync(injurie);    
            if(!validation.IsValid) { throw new ValidationException(validation.Errors); }

            var newinjury = await _Irepository.AddAsync(injurie);

            
            return Response.Success(newinjury.Adapt<Injury, InjuryDto>(), "Injury added succesufly");
        }
    }
}
