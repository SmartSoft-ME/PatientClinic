using Application.IRepositories;
using CleanApiSample.Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using infrastructure;

namespace Infrastructure
{
    public static class Extension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository,PatientRepository>();
            services.AddScoped<IInjuryRepository, InjuryRepository>();
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var connectionString = "Data Source=" + Path.Join(path, "Patients.db");
            services.AddDbContext<PatientDbcontext>(options
              => options.UseSqlite(connectionString));
            services.AddHostedService<AppInitializer>();
            return services;
        }
    }
        
}    
