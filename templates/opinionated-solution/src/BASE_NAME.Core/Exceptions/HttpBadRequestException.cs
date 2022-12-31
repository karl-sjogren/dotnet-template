using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpBadRequestException : HttpExceptionBase {
    public HttpBadRequestException() : base(HttpStatusCode.BadRequest, null) {
    }

    public HttpBadRequestException(string? responseMessage) : base(HttpStatusCode.BadRequest, responseMessage) {
    }

    public HttpBadRequestException(string? responseMessage, string message) : base(HttpStatusCode.BadRequest, responseMessage, message) {
    }

    public HttpBadRequestException(string? responseMessage, string message, Exception innerException) : base(HttpStatusCode.BadRequest, responseMessage, message, innerException) {
    }
}
