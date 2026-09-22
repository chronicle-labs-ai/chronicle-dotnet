using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Links;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateEventLinkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "source_event_id": "source_event_id",
              "target_event_id": "target_event_id",
              "link_type": "link_type",
              "confidence": 1.1
            }
            """;

        const string mockResponse = """
            {
              "link_id": "link_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/event-links")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Links.CreateEventLinkAsync(
            new CreateLinkRequest
            {
                SourceEventId = "source_event_id",
                TargetEventId = "target_event_id",
                LinkType = "link_type",
                Confidence = 1.1,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
