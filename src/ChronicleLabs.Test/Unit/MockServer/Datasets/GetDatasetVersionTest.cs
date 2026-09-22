using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetDatasetVersionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "clusters": [
                {
                  "color": "color",
                  "description": "description",
                  "id": "id",
                  "label": "label",
                  "similarityCenter": [
                    1.1
                  ],
                  "traceIds": [
                    "traceIds"
                  ]
                }
              ],
              "dataset": {
                "archivedAt": "2024-01-15T09:30:00.000Z",
                "createdBy": "createdBy",
                "description": "description",
                "eventCount": 1,
                "id": "id",
                "name": "name",
                "purpose": "eval",
                "tags": [
                  "tags"
                ],
                "traceCount": 1,
                "updatedAt": "2024-01-15T09:30:00.000Z"
              },
              "edges": [
                {
                  "fromTraceId": "fromTraceId",
                  "toTraceId": "toTraceId",
                  "weight": 1.1
                }
              ],
              "events": [
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
              "tasks": [
                {
                  "membershipId": "membershipId",
                  "subjectKind": "trace",
                  "task": {},
                  "traceId": "traceId",
                  "verifiers": [
                    {
                      "id": "id",
                      "kind": "rubric",
                      "label": "label",
                      "source": "proposed",
                      "weight": "low"
                    }
                  ]
                }
              ],
              "traces": [
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
                  "note": "note",
                  "primarySource": "primarySource",
                  "sources": [
                    "sources"
                  ],
                  "split": "train",
                  "startedAt": "2024-01-15T09:30:00.000Z",
                  "status": "ok",
                  "traceId": "traceId"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/versions/version_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.GetDatasetVersionAsync(
            new GetDatasetVersionRequest { DatasetId = "dataset_id", VersionId = "version_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
