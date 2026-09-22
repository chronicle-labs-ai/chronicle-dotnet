using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using global::System.Globalization;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Agents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RegisterAgentArtifactTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
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
              }
            }
            """;

        const string mockResponse = """
            {
              "artifact": {
                "artifactId": "artifactId",
                "configHash": "configHash",
                "description": "description",
                "framework": "vercel-ai-sdk",
                "inputContractPreview": {
                  "example": {
                    "key": "value"
                  },
                  "schemaSummary": "schemaSummary"
                },
                "instructions": "instructions",
                "instructionsHash": "instructionsHash",
                "knowledgeSources": [
                  {
                    "id": "id",
                    "kind": "vector",
                    "label": "label"
                  }
                ],
                "metadata": {
                  "key": "value"
                },
                "model": {
                  "label": "label",
                  "modelId": "modelId",
                  "provider": "provider"
                },
                "name": "name",
                "outputContractPreview": {
                  "example": {
                    "key": "value"
                  },
                  "schemaSummary": "schemaSummary"
                },
                "policy": {
                  "allowedTools": [
                    "allowedTools"
                  ],
                  "approvalRequired": [
                    "approvalRequired"
                  ],
                  "maxSteps": 1,
                  "metadata": {
                    "key": "value"
                  }
                },
                "provenance": {
                  "aiSdkVersion": "aiSdkVersion",
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "dependencyLockHash": "dependencyLockHash",
                  "frameworkVersion": "frameworkVersion",
                  "gitSha": "gitSha",
                  "publishedBy": "publishedBy"
                },
                "providerOptions": {
                  "key": "value"
                },
                "providerOptionsHash": "providerOptionsHash",
                "schemaVersion": "schemaVersion",
                "tools": [
                  {
                    "name": "name"
                  }
                ],
                "version": "version",
                "workflowGraphPreview": {
                  "edges": [
                    {
                      "from": "from",
                      "to": "to"
                    }
                  ],
                  "nodes": [
                    {
                      "id": "id",
                      "kind": "input",
                      "label": "label"
                    }
                  ]
                }
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/agents/register")
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

        var response = await Client.Agents.RegisterAgentArtifactAsync(
            new RegisterAgentArtifactRequest
            {
                Artifact = new RegisterAgentArtifactRequestArtifact
                {
                    ArtifactId = "artifactId",
                    ConfigHash = "configHash",
                    Framework = RegisterAgentArtifactRequestArtifactFramework.VercelAiSdk,
                    Model = new RegisterAgentArtifactRequestArtifactModel { Label = "label" },
                    Name = "name",
                    Provenance = new RegisterAgentArtifactRequestArtifactProvenance
                    {
                        CreatedAt = DateTime.Parse(
                            "2024-01-15T09:30:00.000Z",
                            null,
                            DateTimeStyles.AdjustToUniversal
                        ),
                    },
                    SchemaVersion = "schemaVersion",
                    Tools = new List<RegisterAgentArtifactRequestArtifactToolsItem>()
                    {
                        new RegisterAgentArtifactRequestArtifactToolsItem { Name = "name" },
                    },
                    Version = "version",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
