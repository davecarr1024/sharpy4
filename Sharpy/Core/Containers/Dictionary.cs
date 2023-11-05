using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Sharpy.Core.Containers;

public class Dictionary<K, V> : IImmutableDictionary<K, V>
    where K : notnull
    where V : notnull
{
    public Dictionary(IImmutableDictionary<K, V> items) => Items = items;

    public Dictionary() : this(ImmutableDictionary.Create<K, V>()) { }

    public IImmutableDictionary<K, V> Items { get; init; }

    public IEnumerable<K> Keys => Items.Keys;

    public IEnumerable<V> Values => Items.Values;

    public int Count => Items.Count;

    public V this[K key] => ((IReadOnlyDictionary<K, V>)Items)[key];

    public override bool Equals(object? obj) => obj is Dictionary<K, V> rhs && Items.SequenceEqual(rhs.Items);

    public override int GetHashCode() => Items.GetHashCode();

    public override string ToString()
        => $"{{{string.Join(", ", Items.Select(item => $"{item.Key}:{item.Value}"))}}}";

    public IImmutableDictionary<K, V> Add(K key, V value)
    {
        return Items.Add(key, value);
    }

    public IImmutableDictionary<K, V> AddRange(IEnumerable<KeyValuePair<K, V>> pairs)
    {
        return Items.AddRange(pairs);
    }

    public IImmutableDictionary<K, V> Clear()
    {
        return Items.Clear();
    }

    public bool Contains(KeyValuePair<K, V> pair)
    {
        return Items.Contains(pair);
    }

    public IImmutableDictionary<K, V> Remove(K key)
    {
        return Items.Remove(key);
    }

    public IImmutableDictionary<K, V> RemoveRange(IEnumerable<K> keys)
    {
        return Items.RemoveRange(keys);
    }

    public IImmutableDictionary<K, V> SetItem(K key, V value)
    {
        return Items.SetItem(key, value);
    }

    public IImmutableDictionary<K, V> SetItems(IEnumerable<KeyValuePair<K, V>> items)
    {
        return Items.SetItems(items);
    }

    public bool TryGetKey(K equalKey, out K actualKey)
    {
        return Items.TryGetKey(equalKey, out actualKey);
    }

    public bool ContainsKey(K key)
    {
        return Items.ContainsKey(key);
    }

    public bool TryGetValue(K key, [MaybeNullWhen(false)] out V value)
    {
        return Items.TryGetValue(key, out value);
    }

    public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Items).GetEnumerator();
    }
}