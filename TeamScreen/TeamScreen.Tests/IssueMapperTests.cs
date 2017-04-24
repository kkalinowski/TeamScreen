using System.Linq;
using Shouldly;
using TeamScreen.Plugin.Jira.Integration;
using TeamScreen.Plugin.Jira.Mapping;
using Xunit;

namespace TeamScreen.Tests
{
    public class IssueMapperTests
    {
        private readonly IIssueMapper _issueMapper = new IssueMapper();

        [Fact]
        public void map_correctly_maps_valid_response()
        {
            const string todoName = "todo";
            const int todoId = 10;
            const string doneName = "done";
            const int doneId = 12;

            var board = new GetBoardConfigurationResponse
            {
                ColumnConfig = new ColumnConfiguration
                {
                    Columns = new[]
                    {
                        new Column
                        {
                            Name = todoName,
                            Statuses = new[] {new Status {Id = todoId}}
                        },
                        new Column
                        {
                            Name = doneName,
                            Statuses = new[] {new Status {Id = doneId}}
                        }
                    }
                }
            };

            const string issue1Key = "issue1Key";
            const string issue1Summary = "issue1Summary";
            const string issue2Key = "issue2Key";
            const string issue2Summary = "issue2Summary";
            const string assignee = "assignee";
            var issues = new GetIssuesForSprintResponse
            {
                Issues = new[]
                {
                    new Issue
                    {
                        Key = issue1Key,
                        Fields = new Fields
                        {
                            Summary = issue1Summary,
                            Status = new Status {Id = todoId},
                            Assignee = new Assignee {Name = assignee}
                        }
                    },
                    new Issue
                    {
                        Key = issue2Key,
                        Fields = new Fields
                        {
                            Summary = issue2Summary,
                            Status = new Status {Id = doneId},
                            Assignee = new Assignee {Name = assignee}
                        }
                    }
                }
            };

            var result = _issueMapper.Map(issues, board);
            result.Length.ShouldBe(2);

            var todoResult = result[0];
            todoResult.Column.ShouldBe(todoName);
            todoResult.Issues.ShouldHaveSingleItem();
            var todoissue = todoResult.Issues.First();
            todoissue.ShouldNotBeNull();
            todoissue.Key.ShouldBe(issue1Key);
            todoissue.Fields.Summary.ShouldBe(issue1Summary);
            todoissue.Fields.Assignee.Name.ShouldBe(assignee);

            var doneResult = result[1];
            doneResult.Column.ShouldBe(doneName);
            doneResult.Issues.ShouldHaveSingleItem();
            var doneissue = doneResult.Issues.First();
            doneissue.ShouldNotBeNull();
            doneissue.Key.ShouldBe(issue2Key);
            doneissue.Fields.Summary.ShouldBe(issue2Summary);
            doneissue.Fields.Assignee.Name.ShouldBe(assignee);
        }
    }
}