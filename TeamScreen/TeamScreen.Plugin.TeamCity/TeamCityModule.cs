using Autofac;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.TeamCity.Integration;
using TeamScreen.Plugin.TeamCity.Mapping;

namespace TeamScreen.Plugin.TeamCity
{
    public class TeamCityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TeamCityService>().As<ITeamCityService>();
            builder.RegisterType<BuildMapper>().As<IBuildMapper>();
            builder.RegisterType<TeamCityPlugin>().As<IPlugin>().PreserveExistingDefaults();
        }
    }
}