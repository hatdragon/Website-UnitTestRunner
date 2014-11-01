using System.Web;
using System.Web.SessionState;

namespace WebsiteUnitTestRunner.Testing.UnitTesting
{
    public abstract class UnitTestBaseHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            ProcessRequest(new HttpContextWrapper(context));
        }

        public abstract void ProcessRequest(HttpContextBase context);
    }
}
