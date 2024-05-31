namespace OBilet.Web.Core.Session
{
    public interface ISessionInfoProvider
    {
        void Set<T>(string key, T value);

        T Get<T>(string key) where T : class;

        Task<T> GetOrSetAsync<T>(string key, Func<ValueTask<T>> act) where T : class;
    }
}
