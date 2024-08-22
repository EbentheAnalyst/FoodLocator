using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodLocator.Models
{
    public class Food
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Location> Locations { get; set; }
        public string Category { get; set; } // Add this property
    }
}
