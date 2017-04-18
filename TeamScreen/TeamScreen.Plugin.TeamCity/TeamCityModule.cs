using Autofac;
using TeamScreen.Plugin.TeamCity.Integration;
using TeamScreen.Plugin.TeamCity.Mapping;

namespace TeamScreen.Plugin.TeamCity
{
    public class TeamCityModule : Module
    {
            public bool ObeySpeedLimit { get; set; }

            protected override void Load(ContainerBuilder builder)
            {
                builder.RegisterType<TeamCityService>().As<ITeamCityService>();
                builder.RegisterType<BuildMapper>().As<IBuildMapper>();
        }
    }
}