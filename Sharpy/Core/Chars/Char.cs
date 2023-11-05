namespace Sharpy.Core.Chars
{
    public record Char(char Value, Position Position)
    {
        public Char(char value) : this(value, new()) { }
    }
}