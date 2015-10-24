using System.Collections.Generic;
using Kidly.CanonicalUrls;
using Kidly.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Kidly.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCanonicalUrls(new Dictionary<string, string>
            {
                { "/home/", "/" },
                { "/default/", "/" },
                { "/index/", "/"}
            });
            ConfigureAuth(app);
        }
    }
}
