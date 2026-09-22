using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetSavedViewsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "createdBy": "createdBy",
                "description": "description",
                "id": "id",
                "name": "name",
                "scope": "personal",
                "shortcut": "shortcut",
                "state": {
                  "density": "density",
                  "displayProperties": [
                    "displayProperties"
                  ],
                  "groupBy": "groupBy",
                  "lens": "lens",
                  "ordering": "ordering",
                  "search": "search",
                  "showEmptyGroups": true,
                  "sorting": [
                    {
                      "desc": true,
                      "id": "id"
                    }
                  ]
                },
                "updatedAt": "2024-01-15T09:30:00.000Z"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/saved-views")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetSavedViewsAsync(
            new ListDatasetSavedViewsRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
