using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace BASE_NAME.TestHelpers.Http;

public class FakeHttpContent : HttpContent {
    public string Content { get; set; }

    public FakeHttpContent(string content, string? mediaType = null) {
        Content = content ?? throw new ArgumentNullException(nameof(content));

        if(mediaType is not null) {
            Headers.ContentType = new MediaTypeHeaderValue(mediaType);
        }
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context) {
        var byteArray = Encoding.UTF8.GetBytes(Content);
        await stream.WriteAsync(byteArray);
    }

    protected override bool TryComputeLength(out long length) {
        length = Encoding.UTF8.GetBytes(Content).LongLength;
        return true;
    }
}
