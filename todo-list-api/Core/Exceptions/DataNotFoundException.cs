namespace TodoList.Core.Exceptions;

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string msg)
        : base(msg)
    { }
}