namespace Sharpy.Core.Regex;

public abstract record NaryRegex(Containers.List<Regex> Children) : Regex
{
    public NaryRegex(params Regex[] children) : this(new Containers.List<Regex>(children)) { }
}