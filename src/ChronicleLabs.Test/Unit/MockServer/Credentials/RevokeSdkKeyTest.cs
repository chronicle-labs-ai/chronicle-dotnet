using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Credentials;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class RevokeSdkKeyTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest()
    {
        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/sdk-keys/key_id")
                    .UsingDelete()
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Credentials.RevokeSdkKeyAsync(new RevokeSdkKeyRequest { KeyId = "key_id" })
        );
    }
}
