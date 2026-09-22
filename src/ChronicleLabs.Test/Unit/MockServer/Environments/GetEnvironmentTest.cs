using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Environments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetEnvironmentTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
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
                    .WithPath("/v1/environments/environment_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Environments.GetEnvironmentAsync(
            new GetEnvironmentRequest { EnvironmentId = "environment_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
