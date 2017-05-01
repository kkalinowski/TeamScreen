using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.HealthCheck.Models
{
    public class HealthCheckSettings : ISettings<HealthCheckSettings>
    {
        public SingleHealthCheckSettings[] Settings { get; set; }

        public HealthCheckSettings WithDefaultValues()
        {
            Settings = new SingleHealthCheckSettings[0];
            return this;
        }
    }

    public class SingleHealthCheckSettings
    {
        public string Url { get; set; }
        public string Name { get; set; }
    }

    public enum HealthCheckType
    {
        Web = 1,
    }
}