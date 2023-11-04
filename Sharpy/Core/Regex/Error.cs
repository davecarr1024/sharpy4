namespace Sharpy.Core.Regex;

public class Error : Errors.NaryError
{
    public Error(Regex regex, string message, IReadOnlyCollection<Errors.Error> children)
        : base(message, children)
        => Regex = regex;

    public Regex Regex { get; init; }
}