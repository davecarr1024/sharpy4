namespace Sharpy.Core.Streams
{
    public abstract class Stream<S, T> where S : Stream<S, T>, new()
    {
        public IReadOnlyList<T> Items { get; init; } = new List<T>();

        public override string ToString() => $"[{string.Join(", ", Items)}]";

        public override bool Equals(object? obj) => obj is Stream<S, T> rhs && Items.SequenceEqual(rhs.Items);

        public override int GetHashCode() => Items.GetHashCode();

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
            return new S() { Items = Items.Skip(1).ToList() };
        }
    }
}