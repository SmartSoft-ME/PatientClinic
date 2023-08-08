using Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IInjuryRepository : IBaseRepository<Injury>
    {
        Task<Injury> AddAsync(Injury entity);
        Task<Injury> UpdateAsync(Injury entity);
             
        Task<Injury> AddPatient(int id,string name,string address,int age);
    }
}