namespace Sharpy.Core.Parser.Rules;

public record Scope<StateType, Result>
    (Containers.Dictionary<string, Rule<StateType, Results.SingleResults<Result>, Result>> Values)
    where Result : notnull
{
    public Scope(params (string, Rule<StateType, Results.SingleResults<Result>, Result>)[] values)
        : this(new Containers.Dictionary<string, Rule<StateType, Results.SingleResults<Result>, Result>>(values)) { }
}