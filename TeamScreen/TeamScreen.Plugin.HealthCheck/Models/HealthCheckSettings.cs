using TeamScreen.Data.Entities;

namespace TeamScreen.Plugin.HealthCheck.Models
{
    public class HealthCheckSettings : ISettings<HealthCheckSettings>
    {
        public HealthCheckSettings WithDefaultValues()
        {
            return this;
        }
    }
}