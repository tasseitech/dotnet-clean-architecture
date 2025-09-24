using System.Text.Json.Serialization;

namespace TasseiTech.Sample.Core.Domain.DTOs;

public class OperationResponse
{

    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("errors")]
    public string Error { get; set; }

    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; }
}
public class OperationResponse<T> : OperationResponse where T : class
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
}