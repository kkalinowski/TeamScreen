namespace TeamScreen.Models.Settings
{
    public class CoreSettings : ISettings<CoreSettings>
    {
        public int Interval { get; set; }

        public CoreSettings WithDefaultValues()
        {
            Interval = 60;

            return this;
        }
    }
}