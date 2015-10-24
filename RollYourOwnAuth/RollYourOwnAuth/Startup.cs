using System.Collections.Generic;
using Kidly.CanonicalUrls;
using Microsoft.Owin;
using Owin;
using RollYourOwnAuth;

[assembly: OwinStartup(typeof(Startup))]
namespace RollYourOwnAuth
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
