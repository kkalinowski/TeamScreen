using System;

namespace TeamScreen.Services.Settings
{
    public interface ISettingsService
    {
        T Get<T>(string plugin);
        void Set<T>(string plugin, T value);
    }

    public class SettingsService : ISettingsService
    {
        public T Get<T>(string plugin)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string plugin, T value)
        {

        }
    }
}