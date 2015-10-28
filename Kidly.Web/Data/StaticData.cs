using System.Collections.Generic;
using System.Linq;
using Kidly.Web.Models;

namespace Kidly.Web.Controllers.Api
{
    public static class StaticData
    {
        public static Product[] Products
        {
            get
            {
                return new[]
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Britax Affinity Pushchair Travel System",
                        Ref = "britax-affinity-pushchair-travel-system",
                        BrandId = 1,
                        Price = 425.00,
                        McId = "psX4668"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Britax B-Agile 3 Wheel Pushchair - Black/Chrome",
                        Ref = "britax-b-agile-3-wheel-pushchair",
                        BrandId = 1,
                        Price = 42,
                        McId = "lu3148"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Britax B-Agile 4 Pushchair - Cool Berry",
                        Ref = "britax-b-agile-4-pushchair",
                        BrandId = 1,
                        Price = 340,
                        McId = "lx3966"
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Britax B.O.B Cosy Toes - Black",
                        Ref = "britax-bob-cosy-toes",
                        BrandId = 1,
                        Price = 64,
                        McId = "la4655"
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Bugaboo Bee3 Pram & Pushchair",
                        Ref = "bugaboo-bee3-pram-pushchair",
                        BrandId = 2,
                        Price = 725,
                        McId = "psA6873"
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Bugaboo Cameleon³ Pushchair Base and Navy Blue Fabric",
                        Ref = "bugaboo-cameleon",
                        BrandId = 2,
                        Price = 855,
                        McId = "la0511"
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Bugaboo Donkey Mono Pram & Pushchair",
                        Ref = "bugaboo-donkey",
                        BrandId = 2,
                        Price = 965,
                        McId = "psR5472"
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Bugaboo Buffalo Escape",
                        Ref = "bugaboo-buffalo",
                        BrandId = 2,
                        Price = 1025,
                        McId = "ld4001"
                    }
                };
            }
        }

        public static Brand[] Brands
        {
            get
            {
                return new[]
                {
                    new Brand
                    {
                        Id = 1,
                        Name = "Britax",
                        Description =
                            "Britax offers one of the most comprehensive ranges of strollers and car seats you’ll find. That’s why we’re constantly innovating to cater for your changing needs." +
                            "With strollers for nipping around town, cruising the streets or exploring the outdoors. With car seats offering easy access, extended rearward facing, or installation to suit any vehicle. All of them designed to smoothly handle whatever life throws at them." +
                            "The only thing we’re never flexible on? Our uncompromising approach to safety.",
                        Products = Products.Where(x => x.BrandId == 1).ToList(),
                        LogoId = "britax_2014"
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Bugaboo",
                        Description =
                            "20 years ago Bugaboo designed the world’s first modular pushchair so you and your youngest travelers could explore the world with ease. Iconic, innovative and loaded with functionality, Bugaboo pushchairs ensure a smooth and smart ride. Built to last, they can be endlessly upgraded to suit your mood, style or journey.",
                        Products = Products.Where(x => x.BrandId == 2).ToList(),
                        LogoId = "bugaboo_2006"
                    }
                };
            }
        }

        public static List<LineItem> LineItems = new List<LineItem>();

        public static LineItem GetLineItem(int id)
        {
            return LineItems.FirstOrDefault(x => x.Product.Id == id);
        }

        public static LineItem CreateLineItem(int id)
        {
            var product = Products.FirstOrDefault(x => x.Id == id);
            product.Brand = Brands.FirstOrDefault(x => x.Id == product.BrandId);


            return new LineItem
            {
                Product = product,
                Quantity = 0
            };            
        }
    }
}