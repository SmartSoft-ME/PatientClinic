using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.IRepositories;
using SQLitePCL;
using System.Threading;
using Domain;
using infrastructure;


namespace Infrastructure.Repositories
{
    internal class PatientRepository : BaseRepository<Patient>, IPatientRepository
    {
        private readonly PatientDbcontext _context;
        private readonly DbSet<Patient> _Patient;

        public PatientRepository(PatientDbcontext context) : base(context)
        {

            _context = context;
            _Patient = context.Set<Patient>();
        }
        public async Task<Patient> UpdateAsync(Patient P)
        {
            var Patient_To_Update = _Patient.Update(P);
            await _context.SaveChangesAsync();
            return Patient_To_Update.Entity;
        }
        public async Task<Patient> AddAsync(Patient P)
        {
            var Patient_To_Add = await _Patient.AddAsync(P);
            await _context.SaveChangesAsync();
            return Patient_To_Add.Entity;
        }
    }
}
