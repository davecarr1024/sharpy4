namespace Sharpy.Core.Streams;

public class Set<T>
{
    public Set() { }

    public Set(IImmutableList<T> items) => Items = items;

    public Set(params T[] items) : this(items.ToImmutableList()) { }

    public IImmutableList<T> Items { get; init; } = ImmutableList.Create<T>();

    public override bool Equals(object? obj) => obj is Set<T> rhs && Items.SequenceEqual(rhs.Items);

    public override int GetHashCode() => Items.GetHashCode();

    public override string ToString() => $"[{string.Join(", ", Items)}]";
}