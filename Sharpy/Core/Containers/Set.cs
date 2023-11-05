using System.Collections;

namespace Sharpy.Core.Containers;

public class Set<T> : IImmutableSet<T>
{
    public Set(IImmutableSet<T> items) => Items = items;

    public Set() : this(ImmutableHashSet.Create<T>()) { }

    public Set(params T[] items) : this(items.ToImmutableHashSet()) { }

    public IImmutableSet<T> Items { get; init; }

    public int Count => Items.Count;

    public override bool Equals(object? obj) => obj is Set<T> rhs && Items.SetEquals(rhs.Items);

    public override int GetHashCode() => Items.GetHashCode();

    public override string ToString()
        => $"{{{string.Join(", ", Items.Select(item => item.ToString()))}}}";

    public IImmutableSet<T> Add(T value)
    {
        return Items.Add(value);
    }

    public IImmutableSet<T> Clear()
    {
        return Items.Clear();
    }

    public bool Contains(T value)
    {
        return Items.Contains(value);
    }

    public IImmutableSet<T> Except(IEnumerable<T> other)
    {
        return Items.Except(other);
    }

    public IImmutableSet<T> Intersect(IEnumerable<T> other)
    {
        return Items.Intersect(other);
    }

    public bool IsProperSubsetOf(IEnumerable<T> other)
    {
        return Items.IsProperSubsetOf(other);
    }

    public bool IsProperSupersetOf(IEnumerable<T> other)
    {
        return Items.IsProperSupersetOf(other);
    }

    public bool IsSubsetOf(IEnumerable<T> other)
    {
        return Items.IsSubsetOf(other);
    }

    public bool IsSupersetOf(IEnumerable<T> other)
    {
        return Items.IsSupersetOf(other);
    }

    public bool Overlaps(IEnumerable<T> other)
    {
        return Items.Overlaps(other);
    }

    public IImmutableSet<T> Remove(T value)
    {
        return Items.Remove(value);
    }

    public bool SetEquals(IEnumerable<T> other)
    {
        return Items.SetEquals(other);
    }

    public IImmutableSet<T> SymmetricExcept(IEnumerable<T> other)
    {
        return Items.SymmetricExcept(other);
    }

    public bool TryGetValue(T equalValue, out T actualValue)
    {
        return Items.TryGetValue(equalValue, out actualValue);
    }

    public IImmutableSet<T> Union(IEnumerable<T> other)
    {
        return Items.Union(other);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Items).GetEnumerator();
    }
}