using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Discover;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEventSchemaTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "org_id": "org_id",
              "source": "stripe",
              "event_type": "payment_intent.succeeded",
              "version": 1,
              "field_names": [
                "field_names"
              ],
              "field_types": [
                "field_types"
              ],
              "sample_event": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/discover/schema/source/event_type")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Discover.GetEventSchemaAsync(
            new GetEventSchemaRequest { Source = "source", EventType = "event_type" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
