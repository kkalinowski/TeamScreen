using Autofac;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Plugin.HealthCheck
{
    public class HealthCheckModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HealthCheckPlugin>().As<IPlugin>().PreserveExistingDefaults();
        }
    }
}