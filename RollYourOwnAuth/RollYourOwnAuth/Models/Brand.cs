using System.Collections.Generic;

namespace RollYourOwnAuth.Controllers
{
    public class Brand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}