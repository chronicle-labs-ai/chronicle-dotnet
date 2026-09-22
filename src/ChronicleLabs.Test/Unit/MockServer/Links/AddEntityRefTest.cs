using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Links;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddEntityRefTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "event_id": "event_id",
              "entity_type": "entity_type",
              "entity_id": "entity_id"
            }
            """;

        const string mockResponse = """
            {
              "status": "ok"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/entity-refs")
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

        var response = await Client.Links.AddEntityRefAsync(
            new AddEntityRefRequest
            {
                EventId = "event_id",
                EntityType = "entity_type",
                EntityId = "entity_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
