namespace DesafioAtos.Infra.Exceptions
{
    public class DataBaseConstraintException : Exception
    {
        public DataBaseConstraintException()
        {
        }

        public DataBaseConstraintException(string message) : base(message)
        {
        }

        public DataBaseConstraintException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}