namespace Sharpy.Core.Chars
{
    public record Position(int Line = 0, int Column = 0)
    {
        public static Position operator +(Position lhs, Char rhs)
        {
            if (rhs.Value == '\n')
            {
                return new Position(lhs.Line + 1, 0);
            }
            else
            {
                return new Position(lhs.Line, lhs.Column + 1);
            }
        }
    }
}