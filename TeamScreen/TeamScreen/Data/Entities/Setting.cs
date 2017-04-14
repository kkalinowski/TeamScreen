namespace TeamScreen.Data.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Plugin { get; set; }
        public string Value { get; set; }

        public static Setting Create(string plugin, string value)
        {
            return new Setting
            {
                Plugin = plugin,
                Value = value
            };
        }
    }
}