using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RemoveTraceFromDatasetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/traces/membership_id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Datasets.RemoveTraceFromDatasetAsync(
                new RemoveTraceFromDatasetRequest
                {
                    DatasetId = "dataset_id",
                    MembershipId = "membership_id",
                }
            )
        );
    }
}
