namespace Sharpy.Core.Tokens;

public class Stream : Containers.Stream<Stream, Token>
{
    public Stream() : base() { }

    public Stream(params Token[] items) : base(items) { }
}
