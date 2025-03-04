
namespace BO;

[Serializable]
public class BLExceptionIdNotExist : Exception
{
    public BLExceptionIdNotExist(string? error) : base(error) { }
    public BLExceptionIdNotExist(string message,Exception innerException):
        base(message,innerException){ }
}
[Serializable]
public class BLExceptionIdAllreadyExist : Exception
{
    public BLExceptionIdAllreadyExist(string? error) : base(error) { }
    public BLExceptionIdAllreadyExist(string message, Exception innerException) :
       base(message, innerException)
    { }
}
[Serializable]
public class BLExceptionInvalidInput : Exception
{
    public BLExceptionInvalidInput(string? error) : base(error) { }
    public BLExceptionInvalidInput(string message, Exception innerException) :
       base(message, innerException)
    { }
}
[Serializable]
public class BLExceptionNotInStock : Exception
{
    public BLExceptionNotInStock(string? error) : base(error) { }
    public BLExceptionNotInStock(string message, Exception innerException) :
       base(message, innerException)
    { }
}
public class BLException:Exception
{
    public BLException(string? error) : base(error) { }
    public BLException(string message, Exception innerException) :
       base(message, innerException)
    { }
}