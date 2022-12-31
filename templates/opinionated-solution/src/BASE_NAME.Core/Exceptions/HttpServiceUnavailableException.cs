using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpServiceUnavailableException : HttpExceptionBase {
    public HttpServiceUnavailableException() : base(HttpStatusCode.ServiceUnavailable, null) {
    }

    public HttpServiceUnavailableException(string? responseMessage) : base(HttpStatusCode.ServiceUnavailable, responseMessage) {
    }

    public HttpServiceUnavailableException(string? responseMessage, string message) : base(HttpStatusCode.ServiceUnavailable, responseMessage, message) {
    }

    public HttpServiceUnavailableException(string? responseMessage, string message, Exception innerException) : base(HttpStatusCode.ServiceUnavailable, responseMessage, message, innerException) {
    }
}
