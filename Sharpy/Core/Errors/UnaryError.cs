namespace Sharpy.Core.Errors
{
    public class UnaryError : Error
    {
        public Error Child { get; init; }

        public UnaryError(string message, Error child) : base(message) => Child = child;
    }
}