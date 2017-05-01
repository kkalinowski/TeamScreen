using System.Collections.Generic;
using System.Threading.Tasks;
using Warden;
using Warden.Core;
using Warden.Watchers.Web;

namespace TeamScreen.Plugin.HealthCheck.Integration
{
    public interface IWardenService
    {
        Task<List<IWardenCheckResult>> DoHealthChecks();
    }

    public class WardenService : IWardenService
    {
        public async Task<List<IWardenCheckResult>> DoHealthChecks()
        {
            var results = new List<IWardenCheckResult>();
            var configuration = Configure(results);
            var warden = WardenInstance.Create(configuration);

            await warden.StartAsync();
            return results;
        }

        private WardenConfiguration Configure(List<IWardenCheckResult> results)
        {
            return WardenConfiguration
                .Create()
                .AddWebWatcher("http://kkalinowski.net")
                .AddWebWatcher("http://kkalinowski.net")
                .AddWebWatcher("http://kkalinowski2.net")
                .AddWebWatcher("http://kkalinowski2.net")
                .SetHooks(x => x.OnIterationCompleted(iteration => results.AddRange(iteration.Results)))
                .RunOnlyOnce()
                .Build();
        }
    }
}