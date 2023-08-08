using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.IRepositories;
using SQLitePCL;
using System.Threading;

using Infrastructure.Repositories;
using Domain;
using infrastructure;

namespace Infrastructure.Repositories
{
    public class InjuryRepository : BaseRepository<Injury>, IInjuryRepository
    {
        private readonly PatientDbcontext _context;
        private readonly DbSet<Injury> _Injury;

        public InjuryRepository(PatientDbcontext context) : base(context)
        {

            _context = context;
            _Injury = context.Set<Injury>();
        }
        public async Task<Injury> UpdateAsync(Injury I)
        {
            var Injury_To_Update = _Injury.Update(I);
            await _context.SaveChangesAsync();
            return Injury_To_Update.Entity;
        }
        public async Task<Injury> AddAsync(Injury I)
        {
            var Injury_To_add = await _Injury.AddAsync(I);
            await _context.SaveChangesAsync();
            return Injury_To_add.Entity;
        }
    }

}