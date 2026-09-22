using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Environments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListEnvironmentsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "environments": [
                {
                  "environment": {
                    "createdAt": "2024-01-15T09:30:00.000Z",
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
              ]
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/v1/environments").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Environments.ListEnvironmentsAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
