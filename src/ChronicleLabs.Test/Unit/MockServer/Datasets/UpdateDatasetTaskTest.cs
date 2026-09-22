using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateDatasetTaskTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "key": "value"
            }
            """;

        const string mockResponse = """
            {
              "addedAt": "2024-01-15T09:30:00.000Z",
              "addedBy": "addedBy",
              "clusterId": "clusterId",
              "durationMs": 1,
              "embedding": [
                1.1,
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
                "sources",
                "sources"
              ],
              "split": "train",
              "startedAt": "2024-01-15T09:30:00.000Z",
              "status": "ok",
              "subjectId": "subjectId",
              "subjectKind": "trace",
              "task": {
                "config": {
                  "agentTimeoutSec": 1.1,
                  "networkMode": "public",
                  "verifierTimeoutSec": 1.1
                },
                "environmentId": "environmentId",
                "environmentVersionId": "environmentVersionId",
                "expectedOutcome": {
                  "key": "value"
                },
                "instruction": "instruction",
                "seedCutoffEventId": "seedCutoffEventId",
                "solution": "solution",
                "title": "title"
              },
              "traceId": "traceId",
              "verifiers": [
                {
                  "passThreshold": 1.1,
                  "scorerId": "scorerId",
                  "weight": "low"
                },
                {
                  "passThreshold": 1.1,
                  "scorerId": "scorerId",
                  "weight": "low"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/tasks/membership_id")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.UpdateDatasetTaskAsync(
            new UpdateDatasetTaskRequest
            {
                DatasetId = "dataset_id",
                MembershipId = "membership_id",
                Body = new Dictionary<object, object?>() { { "key", "value" } },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
