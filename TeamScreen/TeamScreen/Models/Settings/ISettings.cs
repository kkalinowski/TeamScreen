namespace TeamScreen.Models.Settings
{
    public interface ISettings<T> where T : ISettings<T>, new()
    {
        T WithDefaultValues();
    }
}