using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateAgentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "capabilityTags": [
                "capabilityTags"
              ],
              "category": "category",
              "description": "description",
              "environment": "environment",
              "framework": "vercel-ai-sdk",
              "lastDriftAt": "2024-01-15T09:30:00.000Z",
              "lastRunAt": "2024-01-15T09:30:00.000Z",
              "latestVersion": "latestVersion",
              "model": {
                "label": "label",
                "modelId": "modelId",
                "provider": "provider"
              },
              "modelLabel": "modelLabel",
              "name": "name",
              "owner": "owner",
              "personaSummary": "personaSummary",
              "playgroundUrl": "playgroundUrl",
              "purpose": "purpose",
              "runbookUrl": "runbookUrl",
              "successRate": 1.1,
              "totalRuns": 1,
              "versionCount": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/name")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Agents.UpdateAgentAsync(
            new UpdateAgentRequest { Name = "name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
