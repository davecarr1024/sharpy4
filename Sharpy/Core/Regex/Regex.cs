namespace Sharpy.Core.Regex;

public abstract record Regex
{
    public abstract StateAndResult Call(State state);

    public StateAndResult Call(Chars.Stream state) => Call(new State(state));

    public StateAndResult Call(string state) => Call(new Chars.Stream(state));

    public static Regex Load(string value)
        => value.Length switch
        {
            1 => new Literal(value[0]),
            _ => new And(value.Select(c => new Literal(c)).ToArray()),
        };
}