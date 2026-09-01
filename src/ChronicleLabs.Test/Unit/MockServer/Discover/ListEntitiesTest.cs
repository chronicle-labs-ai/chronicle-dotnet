using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Discover;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListEntitiesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "entity_type": "customer",
                  "entity_id": "cust_123",
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
                    .WithPath("/v1/discover/entities/entity_type")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Discover.ListEntitiesAsync(
            new ListEntitiesRequest { EntityType = "entity_type" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
