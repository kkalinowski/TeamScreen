using System;
using System.Linq;
using TeamScreen.Services.TeamCity;
using Xunit;
using Shouldly;
using TeamScreen.Models.TeamCity;
using TeamScreen.TeamCity;

namespace TeamScreen.Tests
{
    public class BuildMapperTests
    {
        private readonly IBuildMapper _buildMapper = new BuildMapper();

        [Fact]
        public void map_returns_empty_collection_when_passing_null()
        {
            var result = _buildMapper.Map(null);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void map_returns_empty_collection_when_passing_empty_array()
        {
            var result = _buildMapper.Map(new BuildJob[0]);
            result.ShouldBeEmpty();
        }

        [Fact]
        public void correctly_maps_succesful_build()
        {
            const string project = "project";
            const string buildName = "build";
            const string user = "user";
            var startDate = DateTime.Now;
            var finishDate = startDate.AddMinutes(12);

            var build = new BuildJob
            {
                Project = new Project { Name = project },
                Name = buildName,
                BuildCollection = new BuildCollection
                {
                    Builds = new[]
                    {
                        new Build
                        {
                            StartDate = startDate,
                            FinishDate = finishDate,
                            State = BuildState.Finished,
                            Status = BuildStatus.Success,
                            Trigger = new BuildTrigger
                            {
                                Type = TriggerType.User,
                                User = new TeamCityUser
                                {
                                    Name = user
                                }
                            }
                        }
                    }
                }
            };

            var result = _buildMapper.Map(new[] { build });
            result.ShouldHaveSingleItem();

            var models = result[project];
            models.ShouldNotBeNull();
            models.ShouldHaveSingleItem();

            var model = models.First();
            model.ShouldNotBeNull();
            model.Name.ShouldBe(buildName);
            model.Date.ShouldBe(finishDate);
            model.Status.ShouldBe(TeamCityStatusModel.Success);
            model.TriggeredBy.ShouldBe(user);
        }
    }
}
