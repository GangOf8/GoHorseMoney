namespace HorseMoney.Domain.Common;

public class BaseResponse<T>(T? data, Error error)
{
    #region Properties

    public T? Data { get; set; } = data;
    public Error Error { get; set; } = Error.None;

    #endregion Properties

    #region Constructors

    public BaseResponse(T data) : this(data, Error.None)
    {
        Data = data;
    }

    public BaseResponse(Error error) : this(default, error)
    {
        Error = error;
    }

    #endregion Constructors
}