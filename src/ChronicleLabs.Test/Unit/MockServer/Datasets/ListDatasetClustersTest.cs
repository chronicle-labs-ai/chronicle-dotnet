using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetClustersTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/clusters")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetClustersAsync(
            new ListDatasetClustersRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
