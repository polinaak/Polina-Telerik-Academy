using FoodAndAlchoholEverywhere.Areas.Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAndAlchoholEverywhere.Areas.Recipes.Controllers
{
    public class RecipesController : Controller
    {
        public List<Recipe> recipes;
        public RecipesController()
        {
            this.recipes = new List<Recipe>() 
            {
                new Recipe(){
                    Id=1,
                    Title="Spagetti Bolonezze",
                    Directions=@"Ingredients
                    1/4 cup extra-virgin olive oil
                    1 medium onion, coarsely chopped
                    2 garlic cloves, peeled and coarsely chopped
                    1 celery stalk, coarsely chopped
                    1 carrot, coarsely chopped
                    1 pound ground chuck beef
                    1 (28-ounce) can crushed tomatoes
                    1/4 cup flat-leaf Italian parsley, chiffonade
                    8 fresh basil leaves, chiffonade
                    Salt and freshly ground black pepper
                    1/4 cup freshly grated Pecorino Romano
                    Directions
                    In a 6 quart pot, add extra-virgin olive oil. When almost smoking, add the onion and garlic and saute 
                    over medium heat until the onions become very soft, about 8 minutes. Add the celery and carrot and saute for 5 minutes.
                    Raise heat to high and add the ground beef. Saute, stirring frequently and breaking up any large lumps and cook until
                    meat is no longer pink, about 8 minutes. Add the tomatoes, parsley and basil and cook over medium low heat until the
                    sauce thickens, about 1/2 hour. Finish bolognese with Pecorino Romano. Check for seasoning.
                    Serve hot.

                    Read more at: http://www.foodnetwork.com/recipes/giada-de-laurentiis/simple-bolognese-recipe3/index.html?oc=linkback"
                    },
            
            new Recipe()
            {
                Id = 3,
                Title = "Pancakes with black currant",
                Directions = @"Ingredients:

                2 cups all-purpose flour, stirred or sifted before measuring
                2 1/2 teaspoons baking powder
                3 tablespoons granulated sugar
                1/2 teaspoon salt
                2 large eggs
                1 1/2 to 1 3/4 cups milk
                2 tablespoons melted butter
                Preparation:

                Sift together flour, baking powder, sugar, and salt. In a separate bowl, whisk together the eggs 
                and 1 1/2 cups of milk; add to flour mixture, stirring only until smooth. Blend in melted butter. If the batter 
                seems too thick to pour, add a little more milk. Cook on a hot, greased griddle, using about 1/4 cup of batter
                for each pancake. Cook until bubbly, a little dry around the edges, and lightly browned on the bottom; turn and
                brown the other side. Recipe for pancakes serves 4."
            },
            new Recipe()
            {
                Id = 2,
                Title = "Homemade Banitza",
                Directions = @"Preparation:
            Take 12 pastry sheets (phyllo). Grease bottom of a pan with butter or oil. Brush 3 sheets with butter. Place sheets one atop the other. Spread 1/3 of filling. Top with 2 more sheets, each brushed with butter or oil. Spread second third of filling. Repeat one more time. Top last layer of filling with 3 oiled sheets. Bake in a moderate oven until a wooden pick inserted in center comes out clean
            Banitsa Fillings
            Cheese Filling
            Ingredients:
            4 eggs
            pinch of baking soda
            1/4 kg sirene (white cheese)

            Beat eggs, adding baking soda, keep beating and add crumbed (or grated or crushed) cheese.
            Spinach Filling
            Ingredients:
            1/2 kg spinach
            1/2 cup yogurt
            1 coffee cup oil (or melted butter)
            1 teaspoon salt
            1 cup crumbed sirene (white cheese)
            3 eggs

            1. Squeeze gently water from spinach (washed and cut in strips). Stew in oil (or melted butter). Leave to cool.
            2. Stir in cheese, eggs and yogurt."
            },
            new Recipe()
            {
                Id = 4,
                Title = "Italian Pizza",
                Directions = @"Ingredients
                2 tablespoons sugar
                1 tablespoon kosher salt*
                1 tablespoon pure olive oil
                3/4 cup warm water
                2 cups bread flour (for bread machines)
                1 teaspoon instant yeast
                Olive oil, for the pizza crust
                Flour, for dusting the pizza peel
                Toppings:
                1 1/2 ounces pizza sauce
                1/2 teaspoon each chopped fresh herbs such as thyme, oregano, red pepper flakes, for example
                A combination of 3 grated cheeses such as mozzarella, Monterey Jack, and provolone
                Directions
                Place the sugar, salt, olive oil, water, 1 cup of flour, yeast, and remaining cup of flour into a standing mixer's work bowl.
                Using the paddle attachment, start the mixer on low and mix until the dough just comes together, forming a ball. Lube the hook
                attachment with cooking spray. Attach the hook to the mixer and knead for 15 minutes on medium speed.
                Tear off a small piece of dough and flatten into a disc. Stretch the dough until thin. Hold
                it up to the light and look to see if the baker's windowpane, or taut membrane, has formed. If the dough tears
                before it forms, knead the dough for an additional 5 to 10 minutes.
                Roll the pizza dough into a smooth ball on the countertop. Place into a stainless steel or
                glass bowl. Add 2 teaspoons of olive oil to the bowl and toss to coat. Cover with plastic wrap and refrigerate
                for 18 to 24 hours.
                Place the pizza stone or tile onto the bottom of a cold oven and turn the oven to its highest
                temperature, about 500 degrees F. If the oven has coils on the oven floor, place the tile onto the lowest rack
                of the oven. Split the pizza dough into 2 equal parts using a knife or a dough scraper. Flatten into a disk onto 
                the countertop and then fold the dough into a ball.
                Wet hands barely with water and rub them onto the countertop to dampen the surface. Roll the
                dough on the surface until it tightens. Cover one ball with a tea towel and rest for 30 minutes.
                Repeat the steps with the other piece of dough. If not baking the remaining pizza immediately,
                spray the inside of a ziptop bag with cooking spray and place the dough ball into the bag. Refrigerate for up to 6 days.
                Read more at: http://www.foodnetwork.com/recipes/alton-brown/pizza-pizzas-recipe4/index.html?oc=linkback"
                
            }
            };
        }
    

        //
        // GET: /Recipes/Recipes/
        public ActionResult Index()
        {

            return View(recipes);
        }
    }
}