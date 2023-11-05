
namespace Sharpy.Core.Processor.Errors;

public class Error : Core.Errors.NaryError
{
    public Error(string message = "", params Core.Errors.Error[] children) : base(message, children)
    {
    }
}