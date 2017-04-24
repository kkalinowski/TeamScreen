using Autofac;
using TeamScreen.Plugin.Jira.Integration;
using TeamScreen.Plugin.Jira.Mapping;

namespace TeamScreen.Plugin.Jira
{
    public class JiraModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<JiraService>().As<IJiraService>();
            builder.RegisterType<IssueMapper>().As<IIssueMapper>();
            builder.RegisterType<JiraPlugin>().As<IPlugin>().PreserveExistingDefaults();
        }
    }
}