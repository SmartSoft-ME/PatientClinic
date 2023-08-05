using Application.DTO;
using Shared.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.PatientQueries
{
   public record GetPatientByIdQueries(int id):IQuery<PatientDto>;
}
