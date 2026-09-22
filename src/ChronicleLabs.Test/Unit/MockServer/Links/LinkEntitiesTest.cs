using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Links;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LinkEntitiesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "from_entity_type": "from_entity_type",
              "from_entity_id": "from_entity_id",
              "to_entity_type": "to_entity_type",
              "to_entity_id": "to_entity_id"
            }
            """;

        const string mockResponse = """
            {
              "linked_count": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/link-entity")
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

        var response = await Client.Links.LinkEntitiesAsync(
            new LinkEntityRequest
            {
                FromEntityType = "from_entity_type",
                FromEntityId = "from_entity_id",
                ToEntityType = "to_entity_type",
                ToEntityId = "to_entity_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
