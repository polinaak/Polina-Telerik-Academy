using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAndAlchoholEverywhere.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string Info { get; set; }

        public string Image { get; set; }
    }
}