﻿using Application.DTO;
using MediatR;
using Shared.Commands;

namespace Application.Commands.PatientCommand
{
    public record CreatePatientCommand( string name, string addresse, int age) : ICommand<PatientDto>;
}
