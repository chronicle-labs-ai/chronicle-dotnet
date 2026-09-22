using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RefreshDatasetTraceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/task-suites/dataset_id/traces/membership_id/refresh")
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

        var response = await Client.Datasets.RefreshDatasetTraceAsync(
            new RefreshDatasetTraceRequest
            {
                DatasetId = "dataset_id",
                MembershipId = "membership_id",
                Body = new RefreshMembershipRequest(),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
