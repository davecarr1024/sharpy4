using Sharpy.Core.Containers;

namespace Sharpy.Core.Errors;

public class NaryError : Error
{
    public NaryError(string message = "", params Error[] children)
        : base(message)
        => Children = new(children);

    public Set<Error> Children { get; init; }
}