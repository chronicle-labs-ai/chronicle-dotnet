using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDatasetEvaluationRunsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "agentLabel": "agentLabel",
                "failedTraceIds": [
                  "failedTraceIds"
                ],
                "id": "id",
                "note": "note",
                "passRate": 1.1,
                "startedAt": "2024-01-15T09:30:00.000Z",
                "status": "passing",
                "taskResults": [
                  {
                    "passed": true,
                    "traceId": "traceId"
                  }
                ],
                "totalCount": 1
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/eval-runs")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListDatasetEvaluationRunsAsync(
            new ListDatasetEvaluationRunsRequest { DatasetId = "dataset_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
