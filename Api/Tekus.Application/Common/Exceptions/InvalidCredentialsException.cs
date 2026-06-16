namespace Tekus.Application.Common.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base("Las credenciales proporcionadas son inválidas.")
        {
        }

        public InvalidCredentialsException(string message)
            : base(message)
        {
        }
    }
}
