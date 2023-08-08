using Application.DTO;
using Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.InjuryCommands
{
    public record UpdateInjuryCommand(int id, string type, string treatment) : ICommand<InjuryDto>;
}

