using System.Collections.Generic;
using System.EnterpriseServices;
using Kidly.CanonicalUrls;
using Kidly.Web;
using Kidly.Web.Data;
using Kidly.Web.Framework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace Kidly.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var productUrlConverter = new ProductUrlConverter(
                new ProductProvider(),
                new ProductUrlIdExtractor(),
                new ProductUrlBuilder());

            app.UseCanonicalUrls(x => x
                .MapUrl("/home/", "/")
                .MapUrl("/home/index/", "/")
                .MapUrl("/default/", "/")
                .MapUrl("/index/", "/")
                .WithTrailingSlash()
                .UseLowerCase()
                .UsingUrlConverter(productUrlConverter));

            ConfigureAuth(app);
        }
    }
}
