namespace Sharpy.Core.Chars;

public class Stream : Containers.Stream<Stream, Char>
{
    public Stream() : base() { }

    public Stream(params Char[] items) : base(items) { }

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
