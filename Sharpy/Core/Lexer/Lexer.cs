namespace Sharpy.Core.Lexer;

public record Lexer(Containers.List<Rule> Rules)
{
    public class Error : Errors.NaryError
    {
        private Error(Lexer lexer, State state, string message, params Errors.Error[] children)
            : base(message, children)
        {
            Lexer = lexer;
            State = state;
        }

        public Error(Lexer lexer, State state, string message) : this(lexer, state, message, Array.Empty<Errors.Error>()) { }

        public Error(Lexer lexer, State state, params Errors.Error[] children) : this(lexer, state, "", children) { }

        public Lexer Lexer { get; init; }

        public State State { get; init; }
    }

    private Error CreateError(State state, string message) => new(this, state, message);

    private Error CreateError(State state, params Errors.Error[] children) => new(this, state, children);

    public Lexer(params Rule[] rules) : this(new Containers.List<Rule>(rules)) { }

    public Lexer(params (string name, Regex.Regex regex)[] rules)
        : this(rules.Select(rule => new Rule(rule.name, rule.regex)).ToArray()) { }

    public Lexer(params (string name, string regex)[] rules)
        : this(rules.Select(rule => new Rule(rule.name, rule.regex)).ToArray()) { }

    private StateAndResult CallAny(State state)
    {
        List<Errors.Error> errors = new();
        foreach (Rule rule in Rules)
        {
            try
            {
                return rule.Call(state);
            }
            catch (Errors.Error error)
            {
                errors.Add(error);
            }
        }
        throw CreateError(state, errors.ToArray());
    }

    public Tokens.Stream Call(State state)
    {
        List<Tokens.Token> tokens = new();
        while (state.Chars.Any())
        {
            StateAndResult stateAndResult = CallAny(state);
            state = stateAndResult.State;
            tokens.Add(stateAndResult.Result.Token);
        }
        return new Tokens.Stream(tokens.ToArray());
    }

    public Tokens.Stream Call(string state, Chars.Position? position = null)
        => Call(new State(state, position));
}