using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kidly.CanonicalUrls.Converters;
using Microsoft.Owin;

namespace Kidly.CanonicalUrls
{
    public class CanonicalUrlComponent
    {
        private readonly Func<IDictionary<string, object>, Task> _appFunc;
        private readonly IUrlConverter _urlConverter;

        public CanonicalUrlComponent(Func<IDictionary<string, object>, Task> appFunc, IUrlConverter urlConverter)
        {
            _appFunc = appFunc;
            _urlConverter = urlConverter;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);

            if (!owinContext.Request.Path.HasValue)
            {
                await _appFunc(environment);
                return;
            }

            var cannonicalPath = _urlConverter.Convert(owinContext.Request.Path.Value);

            if (cannonicalPath != owinContext.Request.Path.Value)
            {
                Redirect(owinContext, cannonicalPath);
            }
            else
            {
                await _appFunc(environment);
            }
        }

        private void Redirect(IOwinContext context, string urlToRedirect)
        {
            var queryString = context.Request.QueryString.HasValue
                ? context.Request.QueryString.Value
                : string.Empty;

            context.Response.StatusCode = 301;
            context.Response.Headers.Set("Location", string.Format("{0}?{1}", urlToRedirect, queryString));
        }
    }
}