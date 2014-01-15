using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAndAlchoholEverywhere.Areas.Recipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Directions { get; set; }
    }
}