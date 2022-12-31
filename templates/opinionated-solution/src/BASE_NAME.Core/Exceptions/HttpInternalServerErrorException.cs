using System.Net;

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public class HttpInternalServerErrorException : HttpExceptionBase {
    public HttpInternalServerErrorException() : base(HttpStatusCode.InternalServerError, null) {
    }

    public HttpInternalServerErrorException(string? responseMessage) : base(HttpStatusCode.InternalServerError, responseMessage) {
    }

    public HttpInternalServerErrorException(string? responseMessage, string message) : base(HttpStatusCode.InternalServerError, responseMessage, message) {
    }

    public HttpInternalServerErrorException(string? responseMessage, string message, Exception innerException) : base(HttpStatusCode.InternalServerError, responseMessage, message, innerException) {
    }
}
