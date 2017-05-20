using Autofac;
using TeamScreen.Plugin.Base;
using TeamScreen.Plugin.Git.Integration;
using TeamScreen.Plugin.Git.Mapping;

namespace TeamScreen.Plugin.Git
{
    public class GitModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GitPlugin>().As<IPlugin>().PreserveExistingDefaults();
            builder.RegisterType<GitHubService>().As<IGitHubService>();
            builder.RegisterType<GitMapper>().As<IGitMapper>();
        }
    }
}