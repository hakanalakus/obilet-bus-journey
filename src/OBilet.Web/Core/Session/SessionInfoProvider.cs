using System.Text.Json;

namespace OBilet.Web.Core.Session
{
    public class SessionInfoProvider(IHttpContextAccessor httpContextAccessor):ISessionInfoProvider
    {
   
        public void Set<T>(string key, T value) =>
            httpContextAccessor.HttpContext.Session.SetString(key, JsonSerializer.Serialize(value));

        public T Get<T>(string key) where T: class
        {
            var val = httpContextAccessor.HttpContext.Session.GetString(key);
            if (val == null)
                return null;

            return JsonSerializer.Deserialize<T>(val);
        }

        public async Task<T> GetOrSetAsync<T>(string key,Func<ValueTask<T>> act) where T : class
        {
            var val = Get<T>(key);

            if(val == null) 
            {
                var actionValue = await act();
                Set<T>(key, actionValue);
                return actionValue;
            }

            return val;
        }
    }
}
