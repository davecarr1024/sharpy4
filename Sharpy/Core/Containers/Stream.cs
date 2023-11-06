namespace Sharpy.Core.Containers;
public abstract class Stream<S, T> : List<T> where S : Stream<S, T>, new()
{
    public Stream(params T[] items) : base(items) { }

    public T Head
    {
        get
        {
            if (!Items.Any())
            {
                throw new Errors.Error("empty stream");
            }
            return Items[0];
        }
    }

    public S Tail
    {
        get
        {
            if (!Items.Any())
            {
                throw new Errors.Error("empty stream");
            }
            return new S() { Items = Items.Skip(1).ToImmutableList() };
        }
    }
}
