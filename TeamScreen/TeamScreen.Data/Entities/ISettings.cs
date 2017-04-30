namespace TeamScreen.Data.Entities
{
    public interface ISettings<T> where T : ISettings<T>, new()
    {
        T WithDefaultValues();
    }
}