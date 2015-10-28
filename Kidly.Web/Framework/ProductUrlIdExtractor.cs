using System;
using System.Linq;

namespace Kidly.Web.Framework
{
    public class ProductUrlIdExtractor : IProductUrlIdExtractor
    {
        public int? Extract(string url)
        {
            int output;
            
            var idString = url.Split(new [] {"/"}, StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .FirstOrDefault(x => !x.Contains("?"));

            if (Int32.TryParse(idString, out output))
            {
                return output;
            }
            return null;
        }
    }
}