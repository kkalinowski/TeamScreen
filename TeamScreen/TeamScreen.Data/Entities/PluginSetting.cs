namespace TeamScreen.Data.Entities
{
    public class PluginSetting
    {
        public int Id { get; set; }
        public string Plugin { get; set; }
        public string Value { get; set; }

        public static PluginSetting Create(string plugin, string value)
        {
            return new PluginSetting
            {
                Plugin = plugin,
                Value = value
            };
        }
    }
}