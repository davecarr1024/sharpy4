namespace Sharpy.Core.Regex;

public class Error : Errors.NaryError
{
    public Error(Regex regex, string message, params Errors.Error[] children)
        : base(message, children)
        => Regex = regex;

    public Error(Regex regex, params Errors.Error[] children) : this(regex, "", children) { }

    public Regex Regex { get; init; }
}