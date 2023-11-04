namespace Sharpy.Core.Chars
{
    public class Stream : Streams.Stream<Stream, Char>
    {
        public static Stream Load(string value, Position? starting_position = null)
        {
            List<Char> chars = new();
            Position position = starting_position ?? new();
            foreach (char c in value)
            {
                Char char_ = new(c, position);
                chars.Add(char_);
                position += char_;
            }
            return new Stream { Items = chars };
        }
    }
}