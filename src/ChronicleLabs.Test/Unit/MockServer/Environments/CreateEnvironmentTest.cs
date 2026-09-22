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
              "slug": "slug",
              "label": "label"
            }
            """;

        const string mockResponse = """
            {
              "environment": {
                "archivedAt": "2024-01-15T09:30:00.000Z",
                "createdAt": "2024-01-15T09:30:00.000Z",
                "description": "description",
                "id": "id",
                "label": "label",
                "slug": "slug",
                "tenantId": "tenantId"
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
            new CreateEnvironmentRequest { Slug = "slug", Label = "label" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
