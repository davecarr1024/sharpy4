namespace Sharpy.Core.Containers;
public abstract class Stream<S, T> : List<T> where S : Stream<S, T>, new()
{
    public Stream()
    {
    }

    public Stream(IImmutableList<T> items) : base(items)
    {
    }

    public Stream(params T[] items) : this(items.ToImmutableList()) { }

    public T Head()
    {
        if (!Items.Any())
        {
            throw new Errors.Error("empty stream");
        }
        return Items[0];
    }

    public S Tail()
    {
        if (!Items.Any())
        {
            throw new Errors.Error("empty stream");
        }
        return new S() { Items = Items.Skip(1).ToImmutableList() };
    }
}