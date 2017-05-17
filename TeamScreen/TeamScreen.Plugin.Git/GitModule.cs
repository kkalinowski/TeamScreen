using Autofac;
using TeamScreen.Plugin.Base;

namespace TeamScreen.Plugin.Git
{
    public class GitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitPlugin>().As<IPlugin>().PreserveExistingDefaults();
        }
    }
}