namespace Crm.Application.Common.Exceptions
{
    public class AlreadyExistsException : Exception
    {
        public AlreadyExistsException(string name, object key)
            : base($"\"{name}\" ({key}) already exists.") { }
    }
}
