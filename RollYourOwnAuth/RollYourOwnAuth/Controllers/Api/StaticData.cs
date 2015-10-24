using System.Collections.Generic;
using System.Linq;

namespace RollYourOwnAuth.Controllers.Api
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
                        Brand = "Britax",
                        Price = 425.00,
                        McId = "psX4668"
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Britax B-Agile 3 Wheel Pushchair - Black/Chrome",
                        Ref = "britax-b-agile-3-wheel-pushchair",
                        Brand = "Britax",
                        Price = 42,
                        McId = "lu3148"
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Britax B-Agile 4 Pushchair - Cool Berry",
                        Ref = "britax-b-agile-4-pushchair",
                        Brand = "Britax",
                        Price = 340,
                        McId = "lx3966"
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Britax B.O.B Cosy Toes - Black",
                        Ref = "britax-bob-cosy-toes",
                        Brand = "Britax",
                        Price = 64,
                        McId = "la4655"
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Bugaboo Bee3 Pram & Pushchair",
                        Ref = "bugaboo-bee3-pram-pushchair",
                        Brand = "Bugaboo",
                        Price = 725,
                        McId = "psA6873"
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Bugaboo Cameleon³ Pushchair Base and Navy Blue Fabric",
                        Ref = "bugaboo-cameleon",
                        Brand = "Bugaboo",
                        Price = 855,
                        McId = "la0511"
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Bugaboo Donkey Pushchair Base - Aluminium/Black",
                        Ref = "bugaboo-donkey",
                        Brand = "Bugaboo",
                        Price = 910,
                        McId = "lr5472"
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Bugaboo Buffalo Escape",
                        Ref = "bugaboo-buffalo",
                        Brand = "Bugaboo",
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
                        Name = "Britax",
                        Description =
                            "We’ve packed 50 years of experience, passion and understanding of the way families live into one of the world’s most advanced and flexible ranges of car seats and pushchairs." +
                            "We understand that safety needs to work for your child and your lifestyle. We understand that expertly designed products are only effective if they work in the real world. That means a clear purpose and simple, intuitive functionality. We also appreciate that the choices involved can sometimes feel bewildering. Which is why we’ve made it our mission to make safe simple.",
                        Products = Products.Where(x => x.Brand == "Britax").ToList()
                    },
                    new Brand
                    {
                        Name = "Bugaboo",
                        Description =
                            "20 years ago Bugaboo designed the world’s first modular pushchair so you and your youngest travelers could explore the world with ease. Iconic, innovative and loaded with functionality, Bugaboo pushchairs ensure a smooth and smart ride. Built to last, they can be endlessly upgraded to suit your mood, style or journey.",
                        Products = Products.Where(x => x.Brand == "Bugaboo").ToList()
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
            return new LineItem
            {
                Product = Products.FirstOrDefault(x => x.Id == id),
                Quantity = 0
            };            
        }
    }
}