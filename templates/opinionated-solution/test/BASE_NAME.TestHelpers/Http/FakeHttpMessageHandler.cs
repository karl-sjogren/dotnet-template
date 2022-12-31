namespace BASE_NAME.TestHelpers.Http;

public class FakeHttpMessageHandler : HttpMessageHandler {
    private readonly HttpResponseMessage? _response;
    private readonly Func<HttpRequestMessage, CancellationToken, HttpResponseMessage>? _responseFunc;
    private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>>? _asyncResponseFunc;

    public FakeHttpMessageHandler(HttpResponseMessage response) {
        _response = response;
    }

    public FakeHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> responseFunc) {
        _responseFunc = responseFunc;
    }

    public FakeHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> asyncResponseFunc) {
        _asyncResponseFunc = asyncResponseFunc;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        if(_response != null) {
            return _response;
        }

        if(_responseFunc != null) {
            return _responseFunc(request, cancellationToken);
        }

        if(_asyncResponseFunc != null) {
            var response = await _asyncResponseFunc(request, cancellationToken);
            return response;
        }

        throw new InvalidOperationException("This shouldn't be able to happen.");
    }
}
