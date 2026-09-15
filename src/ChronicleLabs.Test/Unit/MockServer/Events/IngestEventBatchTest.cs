using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Events;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IngestEventBatchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            [
              {
                "source": "my-agent",
                "topic": "conversations",
                "event_type": "message.sent"
              }
            ]
            """;

        const string mockResponse = """
            {
              "event_ids": [
                "event_ids"
              ],
              "count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/events/batch")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Events.IngestEventBatchAsync(
            new List<IngestRequest>()
            {
                new IngestRequest
                {
                    Source = "my-agent",
                    Topic = "conversations",
                    EventType = "message.sent",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
