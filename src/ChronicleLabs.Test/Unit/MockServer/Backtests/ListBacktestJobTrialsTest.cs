using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListBacktestJobTrialsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hasMore": true,
              "nextCursor": "nextCursor",
              "nextOffset": 1,
              "rewards": {
                "key": {
                  "key": 1.1
                }
              },
              "trials": [
                {
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
                  "timings": {},
                  "updatedAt": "2024-01-15T09:30:00.000Z"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/backtests/jobs/job_id/trials")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Backtests.ListBacktestJobTrialsAsync(
            new ListBacktestJobTrialsRequest { JobId = "job_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
