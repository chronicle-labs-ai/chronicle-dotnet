using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAgentSnapshotTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "hashIndex": [
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
              ],
              "runs": [
                {
                  "artifactId": "artifactId",
                  "callOptionsHash": "callOptionsHash",
                  "configHash": "configHash",
                  "durationMs": 1,
                  "error": {
                    "message": "message"
                  },
                  "finishedAt": "2024-01-15T09:30:00.000Z",
                  "inputHash": "inputHash",
                  "operation": "generate",
                  "preparedCall": {
                    "hash": "hash"
                  },
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
              ],
              "summary": {
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
              },
              "versions": [
                {
                  "artifact": {
                    "artifactId": "artifactId",
                    "configHash": "configHash",
                    "framework": "vercel-ai-sdk",
                    "model": {
                      "label": "label"
                    },
                    "name": "name",
                    "provenance": {
                      "createdAt": "2024-01-15T09:30:00.000Z"
                    },
                    "schemaVersion": "schemaVersion",
                    "tools": [
                      {
                        "name": "name"
                      }
                    ],
                    "version": "version"
                  },
                  "lastRunAt": "2024-01-15T09:30:00.000Z",
                  "meanDurationMs": 1,
                  "p95DurationMs": 1,
                  "resolvedModelIds": [
                    "resolvedModelIds"
                  ],
                  "runCount": 1,
                  "status": "current",
                  "successRate": 1.1,
                  "totalTokens": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/name/snapshot")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Agents.GetAgentSnapshotAsync(
            new GetAgentSnapshotRequest { Name = "name" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
