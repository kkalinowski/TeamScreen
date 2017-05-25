using System.Collections.Generic;
using System.Linq;

namespace TeamScreen.Models.Settings
{
    public class CoreSettingsModel
    {
        public int Interval { get; set; }
        public PluginUsage[] Plugins { get; set; }

        public CoreSettingsModel()
        {
            //needed for model binding
        }

        public CoreSettingsModel(CoreSettings settings, IEnumerable<string> plugins)
        {
            Interval = settings.Interval;
            Plugins = plugins
                .Select(x => new PluginUsage
                {
                    Name = x,
                    Enabled = settings.EnabledPluggins.Contains(x)
                })
                .ToArray();
        }

        public CoreSettings ToCoreSettings()
        {
            return new CoreSettings
            {
                Interval = Interval,
                EnabledPluggins = Plugins
                    .Where(x => x.Enabled)
                    .Select(x => x.Name)
                    .ToArray()
            };
        }
    }

    public class PluginUsage
    {
        public string Name { get; set; }
        public bool Enabled { get; set; }
    }
}