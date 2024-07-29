using Account.Common.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Account.Api.Base;

public class Response : ObjectResult
{
    public Response([ActionResultObjectValue] object? value, [ActionResultStatusCode] int statusCode = 200) : base(value)
    {
        StatusCode = statusCode;
    }

    private List<Message> InternalMessages { get; set; } = new();
    public List<Message> Messages => InternalMessages;

    public object? Data { get; internal set; }

    public Response AddError(string message)
    {
        StatusCode = 500;
        InternalMessages.Add(new(MessageType.Error, message));
        Value = new { Messages, Data };

        return this;
    }

    public Response AddInfo(string message)
    {
        InternalMessages.Add(new(MessageType.Info, message));
        Value = new { Messages, Data };

        return this;
    }

    public Response AddSuccess(string? message = null)
    {
        message ??= Resource.OperationSuccessfull;

        InternalMessages.Add(new(MessageType.Success, message));
        Value = new { Messages, Data };

        return this;
    }

    public Response AddWarning(string message)
    {
        InternalMessages.Add(new(MessageType.Warning, message));
        Value = new { Messages, Data };

        return this;
    }

    public Response SetData(dynamic data)
    {
        Data = data;
        Value = new { Messages, Data };

        return this;
    }

    public Response SetStatusCode(int statusCode)
    {
        StatusCode = statusCode;
        Value = new { Messages, Data };

        return this;
    }
}