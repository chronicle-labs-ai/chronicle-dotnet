using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hasMore": true,
              "items": [
                {
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
                }
              ],
              "nextCursor": "nextCursor"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/task-suites").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetsAsync(new ListDatasetsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
