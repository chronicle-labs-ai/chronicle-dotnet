using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateDatasetClusterTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "color": "color",
              "label": "label"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/clusters")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.CreateDatasetClusterAsync(
            new CreateClusterRequest
            {
                DatasetId = "dataset_id",
                Color = "color",
                Label = "label",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
