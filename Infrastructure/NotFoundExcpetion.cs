using Shared;
namespace Infrastructure
{
    public class NotFoundExcpetion:PatientException
    {
        public NotFoundExcpetion( int id) : base(   id + " was found.") { }
    }
}
