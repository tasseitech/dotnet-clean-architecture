using System;
using System.Runtime.Serialization;

namespace TasseiTech.Sample.Core.Domain.Exceptions;

[Serializable]
public class BusinessRuleException : Exception
{
    public const int Status200OK = 200;
    public const int Status400BadRequest = 400;

    public int ErrorCode
    {
        get; private set;
    }

    /// <summary>
    /// The HTTP status code to return from the API.
    /// </summary>
    /// <value>
    /// The HTTP status code.
    /// </value>
    public int HttpStatusCode { get; private set; } = Status400BadRequest;
    public object Data;

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleException"/> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="statusCode">The status code.</param>
    public BusinessRuleException(int errorCode,
                                 int statusCode = Status400BadRequest) : base("Internal Error: Code " + errorCode)
    {
        ErrorCode = errorCode;
        HttpStatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleException"/> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The message.</param>
    /// <param name="statusCode">The status code.</param>
    public BusinessRuleException(int errorCode,
                                 string message,
                                 int statusCode = Status400BadRequest) : base(message)
    {
        ErrorCode = errorCode;
        HttpStatusCode = statusCode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessRuleException"/> class.
    /// </summary>
    /// <param name="errorCode">The error code.</param>
    /// <param name="message">The message.</param>
    /// <param name="innerException">The inner exception.</param>
    /// <param name="statusCode">The status code.</param>
    public BusinessRuleException(int errorCode,
                                 string message,
                                 Exception innerException,
                                 int statusCode = Status200OK) : base(message, innerException)
    {
        ErrorCode = errorCode;
        HttpStatusCode = statusCode;
    }

    /// <summary>
    /// Serialisation constructor. Implements ISerializble.
    /// </summary>
    /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
    protected BusinessRuleException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public BusinessRuleException(int errorCode,
                                 string message,
                                 object data,
                                 int statusCode = Status400BadRequest) : base(message)
    {
        ErrorCode = errorCode;
        HttpStatusCode = statusCode;
        Data = data;
    }
}
