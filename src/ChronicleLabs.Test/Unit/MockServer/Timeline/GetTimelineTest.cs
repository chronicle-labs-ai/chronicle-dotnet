using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Timeline;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTimelineTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "data": [
                {
                  "event": {
                    "event_id": "evt_18C8B8D284059DAF4a74c7cc2a3a669d",
                    "org_id": "org_id",
                    "source": "stripe",
                    "topic": "payments",
                    "event_type": "payment_intent.succeeded",
                    "event_time": "2024-01-15T09:30:00.000Z",
                    "ingestion_time": "2024-01-15T09:30:00.000Z",
                    "media": {
                      "media_type": "image/jpeg",
                      "size_bytes": 1000000
                    },
                    "entity_refs": [
                      {
                        "entity_type": "customer",
                        "entity_id": "cust_123"
                      }
                    ]
                  },
                  "entity_refs": [
                    {
                      "event_id": "event_id",
                      "entity_type": "customer",
                      "entity_id": "cust_123",
                      "created_by": "ingestion",
                      "created_at": "2024-01-15T09:30:00.000Z"
                    }
                  ],
                  "search_distance": 1.1
                }
              ],
              "has_more": true,
              "next_cursor": "next_cursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/timeline/entity_type/entity_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Timeline.GetTimelineAsync(
            new GetTimelineRequest { EntityType = "entity_type", EntityId = "entity_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
