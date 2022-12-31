using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpUnauthorizedException : HttpExceptionBase {
    public HttpUnauthorizedException() : base(HttpStatusCode.Unauthorized, null) {
    }

    public HttpUnauthorizedException(string? responseMessage) : base(HttpStatusCode.Unauthorized, responseMessage) {
    }

    public HttpUnauthorizedException(string? responseMessage, string message) : base(HttpStatusCode.Unauthorized, responseMessage, message) {
    }

    public HttpUnauthorizedException(string? responseMessage, string message, Exception innerException) : base(HttpStatusCode.Unauthorized, responseMessage, message, innerException) {
    }
}
