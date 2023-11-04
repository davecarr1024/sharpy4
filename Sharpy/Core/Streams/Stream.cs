namespace Sharpy.Core.Streams
{
    public abstract class Stream<S, T> : Set<T> where S : Stream<S, T>, new()
    {
        public T Head()
        {
            if (!Items.Any())
            {
                throw new Errors.Error("empty stream");
            }
            return Items.First();
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