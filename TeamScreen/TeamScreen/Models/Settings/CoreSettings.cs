using TeamScreen.Data.Entities;

namespace TeamScreen.Models.Settings
{
    public class CoreSettings : ISettings<CoreSettings>
    {
        public int Interval { get; set; }
        public string[] EnabledPluggins { get; set; }

        public CoreSettings WithDefaultValues()
        {
            Interval = 60;
            EnabledPluggins = new string[0];

            return this;
        }
    }
}