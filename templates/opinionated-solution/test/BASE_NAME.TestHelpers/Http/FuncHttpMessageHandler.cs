namespace BASE_NAME.TestHelpers.Http;

public class FuncHttpMessageHandler : HttpMessageHandler {
    private readonly Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> _func;

    public FuncHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> func) {
        _func = func;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
        var responseTask = new TaskCompletionSource<HttpResponseMessage>();
        responseTask.SetResult(_func(request, cancellationToken));
        return responseTask.Task;
    }
}
