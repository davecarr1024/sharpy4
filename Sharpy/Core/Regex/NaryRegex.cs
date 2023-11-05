namespace Sharpy.Core.Regex;

public abstract record NaryRegex(Streams.Set<Regex> Children) : Regex
{
    public NaryRegex(params Regex[] children) : this(new Streams.Set<Regex>(children)) { }
}