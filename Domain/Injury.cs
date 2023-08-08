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



        

        public int PatientId { get; set; } 
        
        public Injury(string type, string treatment, int patient)
        {

            PatientId = patient;
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

