using OBilet.Web.Core.CurrentUser;
using OBilet.Web.Core.Session;

namespace OBilet.Web
{
    public static class ServiceCollectionExtension
    {
        public static void AddOBiletWeb(this IServiceCollection sc) 
        {
            sc.AddSingleton<ISessionInfoProvider,SessionInfoProvider>();
            sc.AddSingleton<ICurrentUser,CurrentUser>();
        }
    }
}
