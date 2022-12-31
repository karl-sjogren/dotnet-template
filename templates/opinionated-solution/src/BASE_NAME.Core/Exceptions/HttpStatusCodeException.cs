using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpStatusCodeException : HttpExceptionBase {
    public HttpStatusCodeException(HttpStatusCode httpStatusCode) : base(httpStatusCode, null) {
    }

    public HttpStatusCodeException(HttpStatusCode httpStatusCode, string? responseMessage) : base(httpStatusCode, responseMessage) {
    }

    public HttpStatusCodeException(HttpStatusCode httpStatusCode, string? responseMessage, string message) : base(httpStatusCode, responseMessage, message) {
    }

    public HttpStatusCodeException(HttpStatusCode httpStatusCode, string? responseMessage, string message, Exception innerException) : base(httpStatusCode, responseMessage, message, innerException) {
    }
}
