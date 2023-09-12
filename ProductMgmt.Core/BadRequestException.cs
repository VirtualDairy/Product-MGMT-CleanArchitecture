namespace ProductMgmt.Core
{
    public abstract class KnownException : Exception 
    {
        public KnownException(string message) : base(message) { }
    }
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }

    public class UnprocessableException : KnownException
    {
        public UnprocessableException(string message):base (message) { }
    }

    public class DuplicateException : KnownException
    {
        public DuplicateException(string message) : base(message) { }
    }
}
