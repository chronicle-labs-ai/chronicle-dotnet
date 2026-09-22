using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateDatasetWithTraceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "dataset": {
                "name": "name"
              },
              "trace": {
                "traceId": "traceId"
              }
            }
            """;

        const string mockResponse = """
            {
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
              "membership": {
                "addedAt": "addedAt",
                "datasetId": "datasetId",
                "datasetName": "datasetName",
                "eventCount": 1,
                "id": "id",
                "note": "note",
                "purpose": "eval",
                "refreshAvailable": true,
                "revision": 1,
                "split": "train",
                "subjectId": "subjectId",
                "subjectKind": "trace",
                "traceId": "traceId"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/with-trace")
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

        var response = await Client.Datasets.CreateDatasetWithTraceAsync(
            new CreateTaskSuiteWithTraceRequest
            {
                Dataset = new CreateTaskSuiteWithTraceRequestDataset { Name = "name" },
                Trace = new CreateTaskSuiteWithTraceRequestTrace { TraceId = "traceId" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
