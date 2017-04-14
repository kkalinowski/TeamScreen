using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TeamScreen.Data;
using TeamScreen.Data.Entities;

namespace TeamScreen.Services.Settings
{
    public interface ISettingsService
    {
        Task<T> Get<T>(string plugin) where T : class;
        Task Set<T>(string plugin, T value) where T : class;
    }

    public class SettingsService : ISettingsService
    {
        private readonly AppDbContext _db;

        public SettingsService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<T> Get<T>(string plugin) where T : class
        {
            var setting = await _db.Settings.FirstOrDefaultAsync(x => x.Plugin == plugin);
            var deserialized = JsonConvert.DeserializeObject(setting.Value, typeof(T));
            return (T)deserialized;
        }

        public async Task Set<T>(string plugin, T value) where T : class
        {
            var jsonValue = JsonConvert.SerializeObject(value);
            var existing = await _db.Settings.FirstOrDefaultAsync(x => x.Plugin == plugin);
            if (existing != null)
                existing.Value = jsonValue;

            await _db.Settings.AddAsync(Setting.Create(plugin, jsonValue));
            await _db.SaveChangesAsync();
        }
    }
}