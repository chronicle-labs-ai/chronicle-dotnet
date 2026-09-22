using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAgentChatSessionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "agentName": "agentName",
              "agentVersion": "agentVersion",
              "artifactId": "artifactId",
              "messages": [
                {
                  "error": "error",
                  "eventIds": [
                    "eventIds"
                  ],
                  "messageId": "messageId",
                  "occurredAt": "2024-01-15T09:30:00.000Z",
                  "role": "user",
                  "steps": [
                    {
                      "eventType": "eventType",
                      "source": "source",
                      "stepId": "stepId",
                      "text": "text",
                      "toolName": "toolName"
                    }
                  ],
                  "text": "text"
                }
              ],
              "runId": "runId",
              "sessionId": "sessionId",
              "startedAt": "2024-01-15T09:30:00.000Z",
              "traceId": "traceId"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/name/chat/sessions/session_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Agents.GetAgentChatSessionAsync(
            new GetAgentChatSessionRequest { Name = "name", SessionId = "session_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
