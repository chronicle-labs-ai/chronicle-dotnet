using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetTaskEventsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hasMore": true,
              "items": [
                {
                  "actor": "actor",
                  "color": "color",
                  "correlationKey": "correlationKey",
                  "id": "id",
                  "message": "message",
                  "occurredAt": "2024-01-15T09:30:00.000Z",
                  "parentEventId": "parentEventId",
                  "payload": {
                    "key": "value"
                  },
                  "source": "source",
                  "stream": "stream",
                  "traceId": "traceId",
                  "traceLabel": "traceLabel",
                  "type": "type"
                }
              ],
              "nextCursor": "nextCursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/tasks/membership_id/events")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetTaskEventsAsync(
            new ListDatasetTaskEventsRequest
            {
                DatasetId = "dataset_id",
                MembershipId = "membership_id",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
