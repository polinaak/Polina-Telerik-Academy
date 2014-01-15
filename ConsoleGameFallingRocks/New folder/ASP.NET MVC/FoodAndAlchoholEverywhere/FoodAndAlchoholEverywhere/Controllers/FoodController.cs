using FoodAndAlchoholEverywhere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAndAlchoholEverywhere.Controllers
{
    public class FoodController : Controller
    {
       public List<Food> food;

        public FoodController()
        {
            this.food = new List<Food>()
            {
                new Food(){Id=1, Name="Spagetti", Ingredients=@"Spaghetti is a long, thin, cylindrical pasta of Italian and Sicilian origin.Spaghetti is made of
                                        semolina or flour and water. Italian dried spaghetti is made from durum wheat semolina, but outside of Italy and Sicily
                                        it may be made with other kinds of flour.", Info=@"Traditionally, most spaghetti was 50 cm (20 in) long, but shorter lengths 
                                        gained in popularity during the latter half of the 20th century and now spaghetti is most commonly available
                                        in 25–30 cm (10–12 in) lengths. A variety of pasta dishes are based on it, from spaghetti alla Carbonara or garlic
                                        and oil to a spaghetti with tomato sauce, meat and other sauces.
                                        Spaghetti is the plural form of the Italian word spaghetto, which is a diminutive of spago, meaning thin string or twine.",
                                        Image = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSceEw726qMHyby4YeZaSZzEGonET_aLK_Vty4LT4mY4jKKBXmG"},
                new Food(){Id=2, Name="Banitza", Ingredients=@"Banitsa (Bulgarian: Баница, also transliterated as banica and banitza) is a traditional
                                        Bulgarian food prepared by layering a mixture of whisked eggs and pieces of cheese between filo pastry and 
                                        then baking it in an oven.", Info=@"Traditionally, lucky charms are put into the pastry on certain occasions, particularly
                                        on New Year's Eve. These charms may be coins or small symbolic objects (e.g., a small piece of a dogwood branch with a
                                        bud, symbolizing health or longevity). More recently, people have started writing happy wishes on small pieces of
                                        paper and wrapping them in tin foil. Wishes may include happiness, health, or success throughout the new year.
                                        Banitsa is served for breakfast with plain yogurt, ayran, or boza. It can be eaten hot or cold. Some varieties 
                                        include banitsa with spinach (spanachena banitsa) or the sweet version, banitsa with milk (mlechna banitsa) or pumpkin (tikvenik).",
                                        Image="http://2.bp.blogspot.com/_48oeUMxCsjE/TL2mQmOcWQI/AAAAAAAAC5g/BGO6xKPzigk/s1600/banitza3.jpg"},
                new Food(){Id=3, Name="Pizza", Ingredients=@"Pizza is an oven-baked, flat, round bread typically topped with a tomato sauce, cheese and
                                        various toppings. ", Info=@" The modern pizza was invented in Naples, Italy, and the dish has since become popular
                                        in many parts of the world. An establishment that makes and sells pizzas is called a pizzeria. Many varieties
                                        of pizza exist worldwide, along with several dish variants based upon pizza. Pizza is cooked in various types
                                        of ovens, and a diverse variety of ingredients and toppings are utilized. In 2009, upon Italy's request,
                                        Neapolitan pizza was safeguarded in the European Union as a Traditional Speciality Guaranteed dish.",
                                        Image="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcTX6HWS0AGN84VhlKexlW4pOuWEuPKYBE64di8fxvp-aDmX_pxV"},
                new Food(){Id=4, Name="Ice-cream", Ingredients=@"Ice cream is a frozen dessert usually made from dairy products, such as milk and cream 
                                        and often combined with fruits or other ingredients and flavours.", Info=@"Most varieties contain sugar, although
                                        some are made with other sweeteners. In some cases, artificial flavourings and colourings are
                                        used in addition to, or instead of, the natural ingredients. The mixture of chosen ingredients
                                        is stirred slowly while cooling, in order to incorporate air and to prevent large ice crystals
                                        from forming. The result is a smoothly textured semi-solid foam that is malleable and can be scooped.",
                                        Image="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQl_lTDJRVURKmKkI83w_rB9JwQYuqgLMpO_fyInrTcycLw0hrt"},
                new Food(){Id=5, Name="Pancakes", Ingredients="English pancakes have three key ingredients: plain flour, eggs, and milk.",
                                        Info=@"A pancake, also known as a hotcake or flapjack is a flat cake, often thin,
                                        flat, and round, prepared from a starch-based batter and cooked
                                        on a hot surface such as griddle or frying pan. In Britain it is often made without a 
                                        raising agent, and is similar to a crêpe. In America, a raising agent is used (typically baking powder).
                                        The American pancake is similar to a Scotch pancake or drop scone.",
                                        Image = "http://www.bbcgoodfood.com/sites/bbcgoodfood.com/files/recipe_images/recipe-image-legacy-id--1273456_8.jpg"}
            };
        }

        //
        // GET: /Food/
        public ActionResult Index()
        {
            return View(food);
        }

        public ActionResult ShowDetails(int id)
        {
            var drinkDetails = food.FirstOrDefault(x => x.Id == id);
            return View(drinkDetails);
        }
	}
}