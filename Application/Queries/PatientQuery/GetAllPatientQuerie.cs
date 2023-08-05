using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Queries;
using Application.DTO;
using MediatR;

namespace Application.Queries.PatientQueries
{
    public record GetAllPatientQuerie: IQuery<List<PatientDto>>;
}
