using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Injury
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Treatment { get; set; }





        public List<Patient> Patients { get; set; } = new(); 
        
        public Injury(string type, string treatment, List<Patient> patient)
        {

            Patients = patient;
            Type = type;
            Treatment = treatment;
            
        }
        public Injury(string type, string treatment)
        {
            Type = type;
            Treatment = treatment;
        }
        public void UpdateInjury(string type,string treatment)
        {
            Treatment = treatment;
            Type = type;
        }
        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }
        
    }
}

