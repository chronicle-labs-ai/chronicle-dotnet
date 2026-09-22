using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetTracesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hasMore": true,
              "items": [
                {
                  "addedAt": "2024-01-15T09:30:00.000Z",
                  "addedBy": "addedBy",
                  "clusterId": "clusterId",
                  "durationMs": 1,
                  "embedding": [
                    1.1
                  ],
                  "eventCount": 1,
                  "label": "label",
                  "membershipId": "membershipId",
                  "note": "note",
                  "primarySource": "primarySource",
                  "refreshAvailable": true,
                  "revision": 1,
                  "sources": [
                    "sources"
                  ],
                  "split": "train",
                  "startedAt": "2024-01-15T09:30:00.000Z",
                  "status": "ok",
                  "subjectId": "subjectId",
                  "subjectKind": "trace",
                  "traceId": "traceId",
                  "verifiers": [
                    {
                      "scorerId": "scorerId"
                    }
                  ]
                }
              ],
              "nextCursor": "nextCursor"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/traces")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetTracesAsync(
            new ListDatasetTracesRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
