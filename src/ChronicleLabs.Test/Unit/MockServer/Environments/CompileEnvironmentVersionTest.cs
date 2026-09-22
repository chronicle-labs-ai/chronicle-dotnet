using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Environments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CompileEnvironmentVersionTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "datasetSnapshotId": "datasetSnapshotId",
              "scenarioId": "scenarioId"
            }
            """;

        const string mockResponse = """
            {
              "environmentId": "environmentId",
              "environmentSlug": "environmentSlug",
              "versionId": "versionId",
              "version": "version",
              "tenantId": "tenantId",
              "datasetSnapshotId": "datasetSnapshotId",
              "scenarioId": "scenarioId",
              "bundleId": "bundleId",
              "sha256": "sha256",
              "uri": "uri",
              "packageUri": "packageUri",
              "rootDir": "rootDir",
              "sizeBytes": 1000000,
              "warnings": [
                "warnings"
              ],
              "files": [
                "files"
              ],
              "manifest": {
                "key": "value"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/environments/environment_id/versions/version_selector/compile")
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

        var response = await Client.Environments.CompileEnvironmentVersionAsync(
            new CompileEnvironmentRequest
            {
                EnvironmentId = "environment_id",
                VersionSelector = "version_selector",
                DatasetSnapshotId = "datasetSnapshotId",
                ScenarioId = "scenarioId",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
