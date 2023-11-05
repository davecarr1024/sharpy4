namespace Sharpy.Core.Regex;

public record Or : NaryRegex
{
    public Or(params Regex[] children) : base(children) { }

    public override StateAndResult Call(State state)
    {
        System.Collections.Generic.List<Errors.Error> errors = new();
        foreach (Regex child in Children)
        {
            try
            {
                return child.Call(state);
            }
            catch (Errors.Error error)
            {
                errors.Add(error);
            }
        }
        throw new Error(this, errors.ToArray());
    }
}