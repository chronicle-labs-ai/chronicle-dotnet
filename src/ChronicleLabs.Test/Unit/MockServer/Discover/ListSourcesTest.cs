using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Discover;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListSourcesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "source": "stripe",
                  "event_types": [
                    "event_types"
                  ],
                  "event_count": 1000000,
                  "first_seen": "2024-01-15T09:30:00.000Z",
                  "last_seen": "2024-01-15T09:30:00.000Z"
                }
              ],
              "next_cursor": "next_cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/discover/sources")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Discover.ListSourcesAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
