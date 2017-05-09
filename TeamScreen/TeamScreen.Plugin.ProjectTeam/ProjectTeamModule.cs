using Autofac;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Plugin.ProjectTeam
{
    public class HealthCheckModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthCheckPlugin>().As<IPlugin>().PreserveExistingDefaults();
        }
    }
}