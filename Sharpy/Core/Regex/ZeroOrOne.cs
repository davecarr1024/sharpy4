namespace Sharpy.Core.Regex;

public record ZeroOrOne : UnaryRegex
{
    public ZeroOrOne(Regex Child) : base(Child)
    {
    }

    public override StateAndResult Call(State state)
    {
        try
        {
            return Child.Call(state);
        }
        catch (Errors.Error)
        {
            return new StateAndResult(state, new Result());
        }
    }
}
