namespace Sharpy.Core.Regex;

public abstract record Regex
{
    public abstract StateAndResult Call(State state);

    public StateAndResult Call(string state) => Call(new State(Chars.Stream.Load(state)));
}