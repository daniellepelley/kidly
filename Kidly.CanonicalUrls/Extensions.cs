using System.Collections.Generic;
using Kidly.CanonicalUrls.Converters;
using Owin;

namespace Kidly.CanonicalUrls
{
    public static class Extensions
    {
        public static void UseCanonicalUrls(this IAppBuilder app)
        {
            app.UseCanonicalUrls(
                new LowerCaseUrlConverter(),
                new TrailingSlashUrlConverter());
        }

        public static void UseCanonicalUrls(this IAppBuilder app, Dictionary<string, string> urlMapping)
        {
            app.UseCanonicalUrls(
                new LowerCaseUrlConverter(),
                new TrailingSlashUrlConverter(),
                new MappedUrlConverter(urlMapping));
        }

        public static void UseCanonicalUrls(this IAppBuilder app, params IUrlConverter[] converters)
        {
            app.UseCanonicalUrls(
                new CompositeUrlConverter(converters));
        }

        public static void UseCanonicalUrls(this IAppBuilder app, IUrlConverter converter)
        {
            app.Use<CanonicalUrlComponent>(converter);
        }
    }
}