using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchAgentHashIndexTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            [
              {
                "agentName": "agentName",
                "artifactId": "artifactId",
                "framework": "vercel-ai-sdk",
                "hash": "hash",
                "kind": "agent.root",
                "observedAt": "2024-01-15T09:30:00.000Z",
                "path": "path",
                "preview": "preview",
                "runId": "runId"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/hash-index")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Agents.SearchAgentHashIndexAsync(
            new SearchAgentHashIndexRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
