using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Sdk;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class IdentifyUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "user_id": "user_id"
            }
            """;

        const string mockResponse = """
            {
              "accepted": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/users/identify")
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

        var response = await Client.Sdk.IdentifyUserAsync(
            new IdentifyUserRequest { UserId = "user_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
