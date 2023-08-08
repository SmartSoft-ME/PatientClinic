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
        public string treatement { get; set; }



        public int PatientId { get; set; } 

        private Injury() { }
       
        public Injury(string type, string treatement)
        {

           
            this.type = type;
            this.treatement = treatement;
            
        }
        public void UpdateI(string type,string treatement)
        {
            this.treatement = treatement;
            this.type = type;
        }
        
    }
}

