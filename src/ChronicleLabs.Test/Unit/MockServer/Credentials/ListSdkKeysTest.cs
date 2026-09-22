using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListSdkKeysTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string mockResponse = """
            {
              "keys": [
                {
                  "createdAt": "2024-01-15T09:30:00.000Z",
                  "id": "id",
                  "lastUsedAt": "2024-01-15T09:30:00.000Z",
                  "name": "name",
                  "prefix": "prefix",
                  "revokedAt": "2024-01-15T09:30:00.000Z",
                  "scopes": [
                    "scopes"
                  ],
                  "tenantId": "tenantId"
                }
              ]
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v1/sdk-keys").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Credentials.ListSdkKeysAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
