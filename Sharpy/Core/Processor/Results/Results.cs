namespace Sharpy.Core.Processor.Results;

public abstract record Results<Result> where Result : notnull
{
    public abstract NoResults<Result> No();

    public abstract SingleResults<Result> Single();

    public abstract OptionalResults<Result> Optional();

    public abstract MultipleResults<Result> Multiple();

    public abstract NamedResults<Result> Named(string name = "");
}