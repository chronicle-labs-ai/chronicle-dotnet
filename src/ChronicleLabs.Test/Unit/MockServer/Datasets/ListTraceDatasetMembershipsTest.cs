using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Datasets;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListTraceDatasetMembershipsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
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
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/traces/trace_id/task-suite-memberships")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Datasets.ListTraceDatasetMembershipsAsync(
            new ListTraceDatasetMembershipsRequest { TraceId = "trace_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
