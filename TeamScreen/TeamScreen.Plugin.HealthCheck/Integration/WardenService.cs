using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamScreen.Plugin.Base.Extensions;
using TeamScreen.Plugin.HealthCheck.Models;
using Warden;
using Warden.Core;
using Warden.Watchers.Web;

namespace TeamScreen.Plugin.HealthCheck.Integration
{
    public interface IWardenService
    {
        Task<List<IWardenCheckResult>> DoHealthChecks(IEnumerable<SingleHealthCheckSettings> settings);
    }

    public class WardenService : IWardenService
    {
        public async Task<List<IWardenCheckResult>> DoHealthChecks(IEnumerable<SingleHealthCheckSettings> settings)
        {
            var results = new List<IWardenCheckResult>();
            var configuration = Configure(settings, results);
            var warden = WardenInstance.Create(configuration);

            await warden.StartAsync();
            return results;
        }

        private WardenConfiguration Configure(IEnumerable<SingleHealthCheckSettings> settings, List<IWardenCheckResult> results)
        {
            var builder = WardenConfiguration
                .Create()
                .AddWebWatcher("http://kkalinowski.net")
                .AddWebWatcher("http://kkalinowski.net")
                .AddWebWatcher("http://kkalinowski2.net")
                .AddWebWatcher("http://kkalinowski2.net");

            settings
                .Select(BuildWebWatcher)
                .ForEach(x => builder.AddWatcher(x));

            var configuration = builder
                .SetHooks(x => x.OnIterationCompleted(iteration => results.AddRange(iteration.Results)))
                .RunOnlyOnce()
                .Build();

            return configuration;
        }

        private WebWatcher BuildWebWatcher(SingleHealthCheckSettings settings)
        {
            var configuration = WebWatcherConfiguration.Create(settings.Url).Build();
            return WebWatcher.Create(settings.Name, configuration);
        }
    }
}