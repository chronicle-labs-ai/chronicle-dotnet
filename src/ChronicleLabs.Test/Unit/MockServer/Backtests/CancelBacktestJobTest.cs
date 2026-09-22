using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CancelBacktestJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "aborted": true,
              "jobId": "jobId",
              "previousStatus": "pending"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/backtests/jobs/job_id/cancel")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Backtests.CancelBacktestJobAsync(
            new CancelBacktestJobRequest { JobId = "job_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
