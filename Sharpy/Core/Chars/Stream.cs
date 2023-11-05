namespace Sharpy.Core.Chars;

public class Stream : Streams.Stream<Stream, Char>
{
    public Stream()
    {
    }

    public Stream(IImmutableList<Char> items) : base(items)
    {
    }

    public Stream(string value, Position? starting_position = null)
    {
        List<Char> chars = new();
        Position position = starting_position ?? new();
        foreach (char c in value)
        {
            Char char_ = new(c, position);
            chars.Add(char_);
            position += char_;
        }
        Items = chars.ToImmutableList();
    }
}
