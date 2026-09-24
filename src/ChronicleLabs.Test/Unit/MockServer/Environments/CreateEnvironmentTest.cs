using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Environments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateEnvironmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "slug": "support-sandbox",
              "label": "Support sandbox",
              "description": "Isolated environment for support-agent backtests."
            }
            """;

        const string mockResponse = """
            {
              "environment": {
                "archivedAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2026-09-24T14:30:00.000Z",
                "description": "Isolated environment for support-agent backtests.",
                "id": "env_01k5z6x7c8v9b0n1m2q3r4s5t6",
                "label": "Support sandbox",
                "slug": "support-sandbox",
                "tenantId": "tenant_example"
              },
              "versions": [
                {
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "environmentId": "environmentId",
                  "id": "id",
                  "spec": {
                    "interception": {}
                  },
                  "status": "draft",
                  "tenantId": "tenantId",
                  "version": "version"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/environments")
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

        var response = await Client.Environments.CreateEnvironmentAsync(
            new CreateEnvironmentRequest
            {
                Slug = "support-sandbox",
                Label = "Support sandbox",
                Description = "Isolated environment for support-agent backtests.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
