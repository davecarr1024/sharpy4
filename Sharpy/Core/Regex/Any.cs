namespace Sharpy.Core.Regex;

public record Any : Regex
{
    public override string ToString() => ".";

    public override StateAndResult Call(State state)
    {
        try
        {
            return new(state.Tail(), new Result(ImmutableList.Create(state.Head())));
        }
        catch (Errors.Error error)
        {
            throw new Error(this, error);
        }
    }
}