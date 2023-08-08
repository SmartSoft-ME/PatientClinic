﻿using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.InjuryCommands
{
    public record CreateInjuryCommand(string type, string treatment) : ICommand<InjuryDto>;
}
