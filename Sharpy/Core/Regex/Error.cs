namespace Sharpy.Core.Regex;

public class Error : Errors.NaryError
{
    public Error(Regex regex, string message, IImmutableList<Errors.Error> children)
        : base(message, children)
        => Regex = regex;

    public Error(Regex regex, string message) : this(regex, message, ImmutableList.Create<Errors.Error>()) { }

    public Error(Regex regex, params Errors.Error[] children) : this(regex, "", children.ToImmutableList()) { }

    public Error(Regex regex, IImmutableList<Errors.Error> children) : this(regex, "", children) { }

    public Regex Regex { get; init; }
}