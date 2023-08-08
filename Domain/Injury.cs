using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Injury
    {
        public int id { get; set; }
        public string type { get; set; }
        public string treatment { get; set; }



        

        public List<Patient> Patients { get; set; } = new();
        public Injury() { }
        public Injury(string type, string treatment, List<Patient> patient)
        {

            Patients = patient;
            this.type = type;
            this.treatment = treatment;
            
        }
        public Injury(string type, string treatment)
        {
            this.type = type;
            this.treatment = treatment;
        }
        public void UpdateI(string type,string treatment)
        {
            this.treatment = treatment;
            this.type = type;
        }
        
    }
}

