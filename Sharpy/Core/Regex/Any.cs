namespace Sharpy.Core.Regex;

public record Any : Regex
{
    public override string ToString() => ".";

    public override StateAndResult Call(State state)
    {
        try
        {
            return new StateAndResult(state.Tail(), new Result(state.Head()));
        }
        catch (Errors.Error error)
        {
            throw new Error(this, error);
        }
    }
}