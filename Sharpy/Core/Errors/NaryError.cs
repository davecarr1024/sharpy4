namespace Sharpy.Core.Errors;

public class NaryError : Error
{
    public NaryError(string message, IReadOnlyCollection<Error> children)
        : base(message)
        => Children = children.ToImmutableList();

    public IReadOnlyCollection<Error> Children { get; init; }
}