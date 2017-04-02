using System;
using TeamScreen.Services.TeamCity;
using Xunit;
using Shouldly;

namespace TeamScreen.Tests
{
    public class BuildMapperTests
    {
        private readonly IBuildMapper _buildMapper = new BuildMapper();

        [Fact]
        public void map_returns_empty_collection_when_passing_null_or_empty_collection()
        {
            var result = _buildMapper.Map(null);
            result.ShouldBeEmpty();
        }
    }
}
