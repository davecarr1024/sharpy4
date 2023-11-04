namespace Sharpy.Core.Streams;

public class Set<T>
{
    public IReadOnlyCollection<T> Items { get; init; } = new List<T>();

    public override bool Equals(object? obj) => obj is Set<T> rhs && Items.SequenceEqual(rhs.Items);

    public override int GetHashCode() => Items.GetHashCode();

    public override string ToString() => $"[{string.Join(", ", Items)}]";
}