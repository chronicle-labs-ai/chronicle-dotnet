using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using global::System.Globalization;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Events;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IngestEventTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "source": "support-agent",
              "topic": "conversations",
              "event_type": "message.sent",
              "entities": {
                "user": "usr_123"
              },
              "payload": {
                "role": "assistant",
                "content": "Your refund is approved."
              },
              "timestamp": "2026-09-24T14:30:00.000Z"
            }
            """;

        const string mockResponse = """
            {
              "event_ids": [
                "evt_01k5z6x7c8v9b0n1m2q3r4s5t6"
              ],
              "count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/events")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Events.IngestEventAsync(
            new IngestRequest
            {
                Source = "support-agent",
                Topic = "conversations",
                EventType = "message.sent",
                Entities = new Dictionary<string, string>() { { "user", "usr_123" } },
                Payload = new Dictionary<object, object?>()
                {
                    { "content", "Your refund is approved." },
                    { "role", "assistant" },
                },
                Timestamp = DateTime.Parse(
                    "2026-09-24T14:30:00.000Z",
                    null,
                    DateTimeStyles.AdjustToUniversal
                ),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
