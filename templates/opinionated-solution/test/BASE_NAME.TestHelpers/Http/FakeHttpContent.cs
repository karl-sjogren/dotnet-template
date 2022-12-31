using System.Net;
using System.Text;

namespace BASE_NAME.TestHelpers.Http;

public class FakeHttpContent : HttpContent {
    public string Content { get; set; }

    public FakeHttpContent(string content) {
        Content = content ?? throw new ArgumentNullException(nameof(content));
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
