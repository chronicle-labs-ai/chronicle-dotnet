using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListBacktestJobsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hasMore": true,
              "nextOffset": 1,
              "runs": [
                {
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
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v1/backtests/jobs").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Backtests.ListBacktestJobsAsync(new ListBacktestJobsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
