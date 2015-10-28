using System;
using Kidly.Web.Models;

namespace Kidly.Web.Framework
{
    public class ProductUrlBuilder : IProductUrlBuilder
    {
        public string Build(Product product)
        {
            if (product.Brand == null ||
                string.IsNullOrEmpty(product.Brand.Name) ||
                string.IsNullOrEmpty(product.Ref))
            {
                throw new ArgumentException();
            }

            return Build(
                GetBrand(product),
                GetRef(product),
                product.Id.ToString());
        }

        private static string GetRef(Product product)
        {
            return product.Ref.ToLowerInvariant();
        }

        private static string GetBrand(Product product)
        {
            return product.Brand.Name.ToLowerInvariant();
        }

        private string Build(string brandName, string productName, string productId)
        {
            return string.Format("/p/{0}/{1}/{2}/",
                brandName,
                productName,
                productId);
        }
    }
}