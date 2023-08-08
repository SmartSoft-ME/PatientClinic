using Shared;
namespace Infrastructure
{
    public class NotFoundException:PatientException
    {
        public NotFoundException( int id) : base(   id + " was found.") { }
    }
}
