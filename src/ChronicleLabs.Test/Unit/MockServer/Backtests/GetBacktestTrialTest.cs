using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetBacktestTrialTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "artifacts": [
                {
                  "contentType": "contentType",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "id": "id",
                  "kind": "agent-log",
                  "path": "path",
                  "sizeBytes": 1000000,
                  "trialId": "trialId"
                }
              ],
              "rewards": {
                "key": 1.1
              },
              "scorers": [
                {
                  "grader": {
                    "id": "id",
                    "kind": "rubric",
                    "label": "label",
                    "source": "proposed",
                    "weight": "low"
                  },
                  "rewardKey": "rewardKey"
                }
              ],
              "steps": [
                {
                  "actor": "environment",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "endedAt": "2024-01-15T09:30:00.000Z",
                  "graderId": "graderId",
                  "id": "id",
                  "kind": "seed-event",
                  "ordinal": 1,
                  "payload": {
                    "key": "value"
                  },
                  "score": 1.1,
                  "startedAt": "2024-01-15T09:30:00.000Z",
                  "status": "ok",
                  "title": "title",
                  "trialId": "trialId"
                }
              ],
              "trial": {
                "agentId": "agentId",
                "agentLabel": "agentLabel",
                "attempt": 1,
                "caseCluster": "caseCluster",
                "caseId": "caseId",
                "createdAt": "2024-01-15T09:30:00.000Z",
                "durationMs": 1,
                "exception": {
                  "kind": "kind",
                  "message": "message"
                },
                "id": "id",
                "instruction": "instruction",
                "isBaseline": true,
                "jobId": "jobId",
                "sandboxId": "sandboxId",
                "status": "pending",
                "tenantId": "tenantId",
                "timings": {
                  "agentRunFinishedAt": "2024-01-15T09:30:00.000Z",
                  "agentRunStartedAt": "2024-01-15T09:30:00.000Z",
                  "agentSetupFinishedAt": "2024-01-15T09:30:00.000Z",
                  "agentSetupStartedAt": "2024-01-15T09:30:00.000Z",
                  "envSetupFinishedAt": "2024-01-15T09:30:00.000Z",
                  "envSetupStartedAt": "2024-01-15T09:30:00.000Z",
                  "verifierFinishedAt": "2024-01-15T09:30:00.000Z",
                  "verifierStartedAt": "2024-01-15T09:30:00.000Z"
                },
                "updatedAt": "2024-01-15T09:30:00.000Z"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/backtests/jobs/job_id/trials/trial_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Backtests.GetBacktestTrialAsync(
            new GetBacktestTrialRequest { JobId = "job_id", TrialId = "trial_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
