using Autofac;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.HealthCheck.Integration;

namespace TeamScreen.Plugin.HealthCheck
{
    public class HealthCheckModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthCheckPlugin>().As<IPlugin>().PreserveExistingDefaults();
            builder.RegisterType<WardenService>().As<IWardenService>();
        }
    }
}