using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateDatasetTracesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        const string requestJson = """
            {
              "patch": {},
              "traceIds": [
                "traceIds"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/traces")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Datasets.UpdateDatasetTracesAsync(
                new UpdateTracesRequest
                {
                    DatasetId = "dataset_id",
                    Patch = new UpdateTracesRequestPatch(),
                    TraceIds = new List<string>() { "traceIds" },
                }
            )
        );
    }
}
