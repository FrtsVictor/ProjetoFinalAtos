namespace DesafioAtos.Service.Exceptions;
public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message) { }
    public BadRequestException() : base() { }
    public BadRequestException(string message, Exception innerExeption) : base(message, innerExeption) { }

}