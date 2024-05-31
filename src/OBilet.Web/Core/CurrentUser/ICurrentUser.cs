namespace OBilet.Web.Core.CurrentUser
{
    public interface ICurrentUser
    {
        string IPAddress { get; }

        int Port { get; }

        string UserAgent { get; }

        string UserAgentVersion { get; }
    }
}
