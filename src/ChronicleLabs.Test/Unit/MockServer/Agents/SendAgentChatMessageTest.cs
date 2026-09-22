using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SendAgentChatMessageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "text": "text"
            }
            """;

        const string mockResponse = """
            {
              "session": {
                "agentName": "agentName",
                "agentVersion": "agentVersion",
                "artifactId": "artifactId",
                "messages": [
                  {
                    "messageId": "messageId",
                    "occurredAt": "2024-01-15T09:30:00.000Z",
                    "role": "user",
                    "text": "text"
                  }
                ],
                "runId": "runId",
                "sessionId": "sessionId",
                "startedAt": "2024-01-15T09:30:00.000Z",
                "traceId": "traceId"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/name/chat/sessions/session_id/messages")
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

        var response = await Client.Agents.SendAgentChatMessageAsync(
            new SendAgentChatMessageRequest
            {
                Name = "name",
                SessionId = "session_id",
                Text = "text",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
