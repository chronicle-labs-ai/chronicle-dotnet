using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBacktestJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "job": {
                "completedTrials": 1,
                "createdAt": "2024-01-15T09:30:00.000Z",
                "createdBy": "createdBy",
                "datasetId": "datasetId",
                "datasetVersionId": "datasetVersionId",
                "exceptionKind": "exceptionKind",
                "failedTrials": 1,
                "finishedAt": "2024-01-15T09:30:00.000Z",
                "id": "id",
                "mode": "replay",
                "nConcurrent": 1,
                "name": "name",
                "recipe": {
                  "key": "value"
                },
                "retryConfig": {
                  "excludeExceptions": [
                    "excludeExceptions"
                  ],
                  "includeExceptions": [
                    "includeExceptions"
                  ],
                  "maxRetries": 1,
                  "maxWaitSec": 1.1,
                  "minWaitSec": 1.1,
                  "waitMultiplier": 1.1
                },
                "sandboxDriver": "docker",
                "scheduledFor": "2024-01-15T09:30:00.000Z",
                "startedAt": "2024-01-15T09:30:00.000Z",
                "status": "pending",
                "tenantId": "tenantId",
                "totalTrials": 1,
                "updatedAt": "2024-01-15T09:30:00.000Z",
                "verdict": "verdict"
              },
              "run": {
                "agentIds": [
                  "agentIds"
                ],
                "datasetLabel": "datasetLabel",
                "divergences": 1,
                "environmentLabel": "environmentLabel",
                "hue": "hue",
                "id": "id",
                "mode": "replay",
                "name": "name",
                "owner": "owner",
                "scheduledFor": "2024-01-15T09:30:00.000Z",
                "status": "running",
                "totalRuns": 1,
                "updatedAt": "2024-01-15T09:30:00.000Z",
                "verdict": "verdict"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/backtests/jobs/job_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Backtests.GetBacktestJobAsync(
            new GetBacktestJobRequest { JobId = "job_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
