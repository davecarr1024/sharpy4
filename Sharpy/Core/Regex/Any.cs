namespace Sharpy.Core.Regex;

public record Any : Regex
{
    public override string ToString() => ".";

    public override StateAndResult Call(State state)
    {
        try
        {
            return new(state.Tail(), new Result(new List<Chars.Char> { state.Head() }));
        }
        catch (Errors.Error error)
        {
            throw new Error(this, "", new List<Errors.Error> { error }.ToImmutableList());
        }
    }
}