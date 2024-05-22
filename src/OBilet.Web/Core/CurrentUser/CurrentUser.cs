using UAParser;

namespace OBilet.Web.Core.CurrentUser
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor):ICurrentUser
    {
        public string IPAddress => 
            httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

        public int Port => 
            httpContextAccessor.HttpContext.Connection.LocalPort;

        public string UserAgent =>
            GetClientInfo().UA.Family;

        public string UserAgentVersion =>
            GetClientInfo().UA.Major + "." +GetClientInfo().UA.Minor;

        private ClientInfo GetClientInfo() 
        {
            var userAgent = httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);

            return c;
        } 

    }
}
