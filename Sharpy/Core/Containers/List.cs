using System.Collections;

namespace Sharpy.Core.Containers;

public class List<T> : IImmutableList<T>
{
    private List(IImmutableList<T> items) => Items = items;

    public List(params T[] items) : this(items.ToImmutableList()) { }

    public T this[int index] => ((IReadOnlyList<T>)Items)[index];

    public IImmutableList<T> Items { get; init; }

    public int Count => Items.Count;

    public IImmutableList<T> Add(T value)
    {
        return Items.Add(value);
    }

    public IImmutableList<T> AddRange(IEnumerable<T> items)
    {
        return Items.AddRange(items);
    }

    public IImmutableList<T> Clear()
    {
        return Items.Clear();
    }

    public override bool Equals(object? obj) => obj is List<T> rhs && Items.SequenceEqual(rhs.Items);

    public IEnumerator<T> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    public override int GetHashCode() => Items.GetHashCode();

    public int IndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer)
    {
        return Items.IndexOf(item, index, count, equalityComparer);
    }

    public IImmutableList<T> Insert(int index, T element)
    {
        return Items.Insert(index, element);
    }

    public IImmutableList<T> InsertRange(int index, IEnumerable<T> items)
    {
        return Items.InsertRange(index, items);
    }

    public int LastIndexOf(T item, int index, int count, IEqualityComparer<T>? equalityComparer)
    {
        return Items.LastIndexOf(item, index, count, equalityComparer);
    }

    public IImmutableList<T> Remove(T value, IEqualityComparer<T>? equalityComparer)
    {
        return Items.Remove(value, equalityComparer);
    }

    public IImmutableList<T> RemoveAll(Predicate<T> match)
    {
        return Items.RemoveAll(match);
    }

    public IImmutableList<T> RemoveAt(int index)
    {
        return Items.RemoveAt(index);
    }

    public IImmutableList<T> RemoveRange(IEnumerable<T> items, IEqualityComparer<T>? equalityComparer)
    {
        return Items.RemoveRange(items, equalityComparer);
    }

    public IImmutableList<T> RemoveRange(int index, int count)
    {
        return Items.RemoveRange(index, count);
    }

    public IImmutableList<T> Replace(T oldValue, T newValue, IEqualityComparer<T>? equalityComparer)
    {
        return Items.Replace(oldValue, newValue, equalityComparer);
    }

    public IImmutableList<T> SetItem(int index, T value)
    {
        return Items.SetItem(index, value);
    }

    public override string ToString() => $"[{string.Join(", ", Items)}]";

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Items).GetEnumerator();
    }
}