using TeamScreen.Data.Entities;
using TeamScreen.Models.Settings;

namespace TeamScreen.Models.Container
{
    public class ContainerModel
    {
        public ApplicationUser User { get; set; }
        public CoreSettings Settings { get; set; }
    }
}
