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



        public List<Patient> Pa { get;  set; } = new();

       
       
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
        public void RemoveP(Patient P) => Pa.Remove(P);

        public void AddP(Patient P) => Pa.Add(P);

        public void AddPS(List<Patient> P) => Pa.AddRange(P);

        public void UpdatePatient(List<Patient> pa)
        {
            Pa.AddRange(pa?.Where(newItem
                => !pa.Contains(newItem)) ?? Enumerable.Empty<Patient>());
            Pa.RemoveAll(oldItem
                    => !pa?.Contains(oldItem) ?? true);
        }
    }
}

