using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;


namespace Application.IRepositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<Patient> AddAsync(Patient entity);
        Task<Patient> UpdateAsync(Patient entity);
        Task<Patient> AddInjuryToPatient(int PatientId,string type,string treatement);
    }
}