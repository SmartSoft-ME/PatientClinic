using Shared;
namespace Infrastructure
{
    public class NotFoundExcpetion:PatientException
    {
        public NotFoundExcpetion(string typeName, int id) : base("No " + typeName + " with Id " + id + " was found.") { }
    }
}
