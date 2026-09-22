using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using global::System.Globalization;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RecordAgentRunsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "runs": [
                {
                  "artifactId": "artifactId",
                  "configHash": "configHash",
                  "operation": "generate",
                  "runId": "runId",
                  "schemaVersion": "schemaVersion",
                  "startedAt": "2024-01-15T09:30:00.000Z",
                  "status": "started",
                  "toolCalls": [
                    {
                      "callId": "callId",
                      "startedAt": "2024-01-15T09:30:00.000Z",
                      "status": "started",
                      "toolName": "toolName"
                    }
                  ]
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "accepted": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/runs/batch")
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

        var response = await Client.Agents.RecordAgentRunsAsync(
            new RecordAgentRunsRequest
            {
                Runs = new List<RecordAgentRunsRequestRunsItem>()
                {
                    new RecordAgentRunsRequestRunsItem
                    {
                        ArtifactId = "artifactId",
                        ConfigHash = "configHash",
                        Operation = RecordAgentRunsRequestRunsItemOperation.Generate,
                        RunId = "runId",
                        SchemaVersion = "schemaVersion",
                        StartedAt = DateTime.Parse(
                            "2024-01-15T09:30:00.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                        Status = RecordAgentRunsRequestRunsItemStatus.Started,
                        ToolCalls = new List<RecordAgentRunsRequestRunsItemToolCallsItem>()
                        {
                            new RecordAgentRunsRequestRunsItemToolCallsItem
                            {
                                CallId = "callId",
                                StartedAt = DateTime.Parse(
                                    "2024-01-15T09:30:00.000Z",
                                    null,
                                    DateTimeStyles.AdjustToUniversal
                                ),
                                Status = RecordAgentRunsRequestRunsItemToolCallsItemStatus.Started,
                                ToolName = "toolName",
                            },
                        },
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
