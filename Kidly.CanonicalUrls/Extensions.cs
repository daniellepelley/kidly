using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

        public static void UseCanonicalUrls(this IAppBuilder app, Action<CanonicalUrlSetUp> action)
        {
            var builder = new CanonicalUrlSetUp();
            action(builder);
            app.Use<CanonicalUrlComponent>(builder.BuildConverters());
        }

        public static IEnumerable<T> OnEach<T>(this IEnumerable<T> source, Action<T> executeAction)
        {
            foreach (var item in source)
            {
                executeAction(item);
            }
            return source;
        }
    }

    public class CanonicalUrlSetUp
    {
        readonly IDictionary<string, string> _mapping;
        private bool _useTrailingSlash;
        private bool _useLowerCase;
        private readonly List<IUrlConverter> _urlConverters; 

        public CanonicalUrlSetUp()
        {
            _mapping = new ConcurrentDictionary<string, string>();
            _urlConverters = new List<IUrlConverter>(); 
        }

        internal IUrlConverter BuildConverters()
        {
            return new CompositeUrlConverter(GetUrlConverters());
        }

        private IUrlConverter GetTrailingSlashConverter()
        {
            return _useTrailingSlash
                ? new TrailingSlashUrlConverter() as IUrlConverter
                : new NoTrailingSlashUrlConverter();
        }

        private IUrlConverter GetCasingConverter()
        {
            return _useLowerCase
                ? new LowerCaseUrlConverter() as IUrlConverter
                : new UpperCaseUrlConverter();
        }

        private IUrlConverter[] GetUrlConverters()
        {
            return new[]
            {
                GetCasingConverter(),
                GetTrailingSlashConverter(),
                new MappedUrlConverter(_mapping)
            }
                .Concat(_urlConverters)
                .ToArray();
        }

        public CanonicalUrlSetUp MapUrl(string from, string to)
        {
            _mapping.Add(from, to);
            return this;
        }

        public CanonicalUrlSetUp MapUrl(IEnumerable<string> from, string to)
        {
            from.OnEach(x => MapUrl(x, to));
            return this;
        }

        public CanonicalUrlSetUp UseLowerCase()
        {
            _useLowerCase = true;
            return this;
        }

        public CanonicalUrlSetUp UseUpperCase()
        {
            _useLowerCase = false;
            return this;
        }

        public CanonicalUrlSetUp WithTrailingSlash()
        {
            _useTrailingSlash = true;
            return this;
        }

        public CanonicalUrlSetUp WithoutTrailingSlash()
        {
            _useTrailingSlash = false;
            return this;
        }

        public CanonicalUrlSetUp UsingUrlConverter(IUrlConverter urlConverter)
        {
            _urlConverters.Add(urlConverter);
            return this;
        }
    }
}