namespace Sharpy.Core.Errors;

public class NaryError : Error
{
    public NaryError(string message, IImmutableList<Error> children)
        : base(message)
        => Children = children.ToImmutableList();

    public IImmutableList<Error> Children { get; init; }
}