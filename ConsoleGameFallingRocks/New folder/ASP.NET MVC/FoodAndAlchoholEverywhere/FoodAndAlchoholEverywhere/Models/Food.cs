using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAndAlchoholEverywhere.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Info { get; set; }

        public string Image { get; set; }
    }
}