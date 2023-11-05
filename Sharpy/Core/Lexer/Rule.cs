namespace Sharpy.Core.Lexer;

public record Rule(string Name, Regex.Regex Regex)
{
    public class Error : Errors.UnaryError
    {
        public Error(Rule rule, Errors.Error child, string message = "") : base(message, child) => Rule = rule;

        public Rule Rule { get; init; }
    }

    public Rule(string name, string regex)
        : this(name, Core.Regex.Regex.Load(regex)) { }

    public StateAndResult Call(State state)
    {
        try
        {
            Regex.StateAndResult stateAndResult = Regex.Call(state.Chars);
            return new StateAndResult(
                new State(stateAndResult.State.Chars),
                new Result(stateAndResult.Result.Token(Name))
            );
        }
        catch (Errors.Error error)
        {
            throw new Error(this, error);
        }
    }

    public StateAndResult Call(string state, Chars.Position? position = null)
        => Call(new State(state, position));
}