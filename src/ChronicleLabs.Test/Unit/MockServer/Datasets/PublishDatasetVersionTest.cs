using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PublishDatasetVersionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "createdAt": "createdAt",
              "createdBy": "createdBy",
              "datasetId": "datasetId",
              "datasetRevision": 1000000,
              "description": "description",
              "eventCount": 1,
              "id": "id",
              "itemCount": 1,
              "label": "label",
              "version": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/versions")
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

        var response = await Client.Datasets.PublishDatasetVersionAsync(
            new PublishVersionRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
