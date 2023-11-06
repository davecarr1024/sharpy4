namespace Sharpy.Core.Tokens;

public class Stream : Containers.Stream<Stream, Token>
{
    public Stream() : base() { }

    public Stream(params Token[] items) : base(items) { }

    public Stream(params (string name, string value)[] items)
        : this(items.Select(item => new Token(item.name, item.value)).ToArray()) { }
}
