using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SetDatasetTaskVerifiersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "verifiers": [
                {
                  "scorerId": "scorerId"
                }
              ]
            }
            """;

        const string mockResponse = """
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
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/tasks/membership_id/verifiers")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPut()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.SetDatasetTaskVerifiersAsync(
            new SetTaskVerifiersRequest
            {
                DatasetId = "dataset_id",
                MembershipId = "membership_id",
                Verifiers = new List<SetTaskVerifiersRequestVerifiersItem>()
                {
                    new SetTaskVerifiersRequestVerifiersItem { ScorerId = "scorerId" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
