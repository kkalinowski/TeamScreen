using System.ComponentModel.DataAnnotations;

namespace TeamScreen.Data.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Plugin { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}