using System.Net;
using BASE_NAME.Core.Common;

namespace BASE_NAME.TestHelpers.Http;

public static class HttpClientActivator<T> where T : HttpClientBase {
    public static async Task<T> GetClientWithResourceResponseAsync(HttpStatusCode httpStatusCode, string resourceName, Func<HttpClient, T> createClient) {
        var responseJson = await Resources.GetStringAsync(resourceName);
        var dummyResponse = new HttpResponseMessage(httpStatusCode) { Content = new FakeHttpContent(responseJson) };
        var client = new HttpClient(new FakeHttpMessageHandler(dummyResponse)) {
            BaseAddress = new Uri("http://www.example.com/")
        };

        return createClient(client);
    }

    public static T GetClient(HttpStatusCode httpStatusCode, Func<HttpClient, T> createClient) {
        var dummyResponse = new HttpResponseMessage(httpStatusCode);
        var client = new HttpClient(new FakeHttpMessageHandler(dummyResponse)) {
            BaseAddress = new Uri("http://www.example.com/")
        };

        return createClient(client);
    }

    public static T GetClient(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> responseFunc, Func<HttpClient, T> createClient) {
        var client = new HttpClient(new FakeHttpMessageHandler(responseFunc)) {
            BaseAddress = new Uri("http://www.example.com/")
        };

        return createClient(client);
    }

    public static T GetClient(Func<HttpRequestMessage, CancellationToken, HttpResponseMessage> responseFunc, Func<HttpClient, T> createClient) {
        var client = new HttpClient(new FakeHttpMessageHandler(responseFunc)) {
            BaseAddress = new Uri("http://www.example.com/")
        };

        return createClient(client);
    }
}
