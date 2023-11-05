namespace Sharpy.Core.Regex;

public record Literal(char Value) : Regex
{
    public override StateAndResult Call(State state)
    {
        try
        {
            if (state.Head().Value == Value)
            {
                return new(state.Tail(), new Result(ImmutableList.Create(state.Head())));
            }
        }
        catch (Errors.Error error)
        {
            throw new Error(this, "", ImmutableList.Create(error));
        }
        throw new Error(this, $"expected char {Value} but got {state}", ImmutableList.Create<Errors.Error>());
    }
}