using MediatR;
using Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.InjuryCommands
{
    public record DeleteInjuryCommand(int id) : ICommand<Unit>;
}
