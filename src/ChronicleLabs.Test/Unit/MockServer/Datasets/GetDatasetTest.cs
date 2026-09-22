using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetDatasetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "clusters": [
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
              ],
              "dataset": {
                "archivedAt": "2024-01-15T09:30:00.000Z",
                "createdBy": "createdBy",
                "description": "description",
                "eventCount": 1,
                "id": "id",
                "name": "name",
                "purpose": "eval",
                "tags": [
                  "tags"
                ],
                "traceCount": 1,
                "updatedAt": "2024-01-15T09:30:00.000Z"
              },
              "edges": [
                {
                  "fromTraceId": "fromTraceId",
                  "toTraceId": "toTraceId",
                  "weight": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.GetDatasetAsync(
            new GetDatasetRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
