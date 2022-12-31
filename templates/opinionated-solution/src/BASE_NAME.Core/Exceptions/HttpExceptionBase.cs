using System.Net;

[assembly: SuppressMessage("Readability", "RCS1194", Justification = "Exceptions inheriting from HttpExceptionBase needs a HttpStatusCode in their constructors.", Scope = "NamespaceAndDescendants", Target = "~N:BASE_NAME.Core.Exceptions")]

namespace BASE_NAME.Core.Exceptions;

[ExcludeFromCodeCoverage]
public abstract class HttpExceptionBase : HttpRequestException {
    public new HttpStatusCode? StatusCode { get; }
    public string? ResponseMessage { get; }

    protected HttpExceptionBase(HttpStatusCode statusCode, string? responseMessage) {
        StatusCode = statusCode;
        ResponseMessage = responseMessage;
    }

    protected HttpExceptionBase(HttpStatusCode statusCode, string? responseMessage, string message) : base(message) {
        StatusCode = statusCode;
        ResponseMessage = responseMessage;
    }

    protected HttpExceptionBase(HttpStatusCode statusCode, string? responseMessage, string message, Exception innerException) : base(message, innerException) {
        StatusCode = statusCode;
        ResponseMessage = responseMessage;
    }
}
