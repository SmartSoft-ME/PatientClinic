using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
   public abstract class PatientException: Exception
    {
        public PatientException(string message):base(message) { }
    }
}
