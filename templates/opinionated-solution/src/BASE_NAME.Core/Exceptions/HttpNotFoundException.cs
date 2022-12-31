using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpNotFoundException : HttpExceptionBase {
    public HttpNotFoundException() : base(HttpStatusCode.NotFound, null) {
    }

    public HttpNotFoundException(string? responseMessage) : base(HttpStatusCode.NotFound, responseMessage) {
    }

    public HttpNotFoundException(string? responseMessage, string message) : base(HttpStatusCode.NotFound, responseMessage, message) {
    }

    public HttpNotFoundException(string? responseMessage, string message, Exception innerException) : base(HttpStatusCode.NotFound, responseMessage, message, innerException) {
    }
}
