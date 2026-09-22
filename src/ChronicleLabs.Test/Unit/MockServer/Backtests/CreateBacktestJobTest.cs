using ChronicleLabs;
using ChronicleLabs.Test.Unit.MockServer;
using ChronicleLabs.Test.Utils;
using NUnit.Framework;

namespace ChronicleLabs.Test.Unit.MockServer.Backtests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateBacktestJobTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async global::System.Threading.Tasks.Task MockServerTest()
    {
        const string requestJson = """
            {
              "name": "name",
              "recipe": {
                "agents": [
                  {
                    "hue": "hue",
                    "id": "id",
                    "label": "label",
                    "notes": "notes"
                  }
                ],
                "data": {
                  "kind": "composed",
                  "scenarios": [
                    {
                      "count": 1,
                      "id": "id",
                      "kind": "adversarial",
                      "label": "label"
                    }
                  ],
                  "sources": [
                    {
                      "count": 1,
                      "id": "id",
                      "kind": "prod",
                      "label": "label"
                    }
                  ]
                },
                "graders": [
                  {
                    "id": "id",
                    "kind": "rubric",
                    "label": "label",
                    "source": "proposed",
                    "weight": "low"
                  }
                ],
                "mode": "replay",
                "name": "name"
              }
            }
            """;

        const string mockResponse = """
            {
              "jobId": "jobId",
              "run": {
                "agentIds": [
                  "agentIds"
                ],
                "datasetLabel": "datasetLabel",
                "divergences": 1,
                "environmentLabel": "environmentLabel",
                "hue": "hue",
                "id": "id",
                "mode": "replay",
                "name": "name",
                "owner": "owner",
                "scheduledFor": "2024-01-15T09:30:00.000Z",
                "status": "running",
                "totalRuns": 1,
                "updatedAt": "2024-01-15T09:30:00.000Z",
                "verdict": "verdict"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1/backtests/jobs")
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

        var response = await Client.Backtests.CreateBacktestJobAsync(
            new CreateBacktestJobRequest
            {
                Name = "name",
                Recipe = new CreateBacktestJobRequestRecipe
                {
                    Agents = new List<CreateBacktestJobRequestRecipeAgentsItem>()
                    {
                        new CreateBacktestJobRequestRecipeAgentsItem
                        {
                            Hue = "hue",
                            Id = "id",
                            Label = "label",
                            Notes = "notes",
                        },
                    },
                    Data = new CreateBacktestJobRequestRecipeData
                    {
                        Kind = CreateBacktestJobRequestRecipeDataKind.Composed,
                        Scenarios = new List<CreateBacktestJobRequestRecipeDataScenariosItem>()
                        {
                            new CreateBacktestJobRequestRecipeDataScenariosItem
                            {
                                Count = 1,
                                Id = "id",
                                Kind =
                                    CreateBacktestJobRequestRecipeDataScenariosItemKind.Adversarial,
                                Label = "label",
                            },
                        },
                        Sources = new List<CreateBacktestJobRequestRecipeDataSourcesItem>()
                        {
                            new CreateBacktestJobRequestRecipeDataSourcesItem
                            {
                                Count = 1,
                                Id = "id",
                                Kind = CreateBacktestJobRequestRecipeDataSourcesItemKind.Prod,
                                Label = "label",
                            },
                        },
                    },
                    Graders = new List<CreateBacktestJobRequestRecipeGradersItem>()
                    {
                        new CreateBacktestJobRequestRecipeGradersItem
                        {
                            Id = "id",
                            Kind = CreateBacktestJobRequestRecipeGradersItemKind.Rubric,
                            Label = "label",
                            Source = CreateBacktestJobRequestRecipeGradersItemSource.Proposed,
                            Weight = CreateBacktestJobRequestRecipeGradersItemWeight.Low,
                        },
                    },
                    Mode = CreateBacktestJobRequestRecipeMode.Replay,
                    Name = "name",
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
