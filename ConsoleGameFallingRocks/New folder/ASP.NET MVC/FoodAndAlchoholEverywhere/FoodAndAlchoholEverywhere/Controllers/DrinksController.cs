using FoodAndAlchoholEverywhere.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodAndAlchoholEverywhere.Controllers
{
    public class DrinksController : Controller
    {
        public List<Drink> drinks;

        public DrinksController()
        {
            this.drinks = new List<Drink>()
            {
                new Drink(){Id=1, Name="Coca-Cola", Type="Soft Drink", Info=@"A soft drink (also called soda, pop, coke, soda pop, fizzy drink, tonic,
                                        seltzer, mineral,[2] sparkling water, lolly water, or carbonated beverage) is a beverage that typically contains
                                        water (often, but not always, carbonated water), usually a sweetener, and usually a flavoring agent. The sweetener 
                                        may be sugar, high-fructose corn syrup, fruit juice, sugar substitutes (in the case of diet drinks) or some 
                                        combination of these. Soft drinks may also contain caffeine, colorings, preservatives and other ingredients.",
                                        Image = "http://offnews.bg/files/uploads/2013/04/coca-cola-1.jpg?325412"},
                new Drink(){Id=2, Name="Cappy", Type="Juice", Info=@"Juice is a liquid that is naturally contained in fruit and vegetables. It can also 
                                        refer to liquids that are flavored with these or other biological food sources such as meat and seafood. It is 
                                        commonly consumed as a beverage or used as an ingredient or flavoring in foods.",
                                        Image="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcTsu0B5twgO9tu8bymejYpVzMzVn8uIuSrVyKbBopzsWGioHC6v"},
                new Drink(){Id=3, Name="Kamenitza", Type="Beer", Info=@"Beer is an alcoholic beverage produced by the saccharification of starch and fermentation of the resulting sugar. The starch and saccharification enzymes are often derived from malted cereal grains, most commonly malted barley and malted wheat.Most beer is also flavoured with hops, which add bitterness and act as a natural preservative, though other flavourings such as herbs or fruit may occasionally be included. The preparation of beer is called brewing.
                                        Beer is the world's most widely consumed alcoholic beverage,
                                        and is the third-most popular drink overall, after water and tea. It is thought
                                        by some to be the oldest fermented beverage",
                                        Image="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAl_oYPPzn0hsyFJ6b1zoIhQTPPecTygdNQUxbv_6ItszGCcQw2w"},
                new Drink(){Id=4, Name="Bubbles", Type="Wine", Info=@"Wine is an alcoholic beverage made from fermented grapes or other fruits. The 
                                        natural chemical balance of grapes lets them ferment without the addition of sugars, acids, enzymes, water, or 
                                        other nutrients. Yeast consumes the sugars in the grapes and converts them into alcohol and carbon dioxide. 
                                        Different varieties of grapes and strains of yeasts produce different styles of wine. The well-known variations
                                        result from the very complex interactions between the biochemical development of the fruit, reactions involved in
                                        fermentation, and human intervention in the overall process. The final product may contain tens of thousands of 
                                        chemical compounds in amounts varying from a few percent to a few parts per billion.",
                                        Image="http://images.5ounces.co.za/Gold-Bubbles-White-Sparkling-Wine-by-Ernst-Gouws-Half-Case-Gold-Bubbles-White-Sparkling-Wine-by-Ernst-Gouws.jpg?q=85&o=JEyJnw$F3HxfF5xV7iDnumZidi0j&v=MVmc"},
                new Drink(){Id=5, Name="Four Roses", Type="Bourbon", Info=@"Four Roses is a Kentucky Straight Bourbon Whiskey brand owned by the Kirin Brewery Company
                                        of Japan. The brand was established in 1888. The trademark was probably named for company founder Rufus Mathewson 
                                        Rose, his brother Origen, and their two sons,[1] although it is somewhat unclear, as several different 
                                        stories have been told about where the name Four Roses comes from.[2] The Lawrenceburg, Kentucky distillery was 
                                        built in 1910 in Spanish Mission-style architecture and is listed on the National Register of Historic Places.",
                                        Image = "http://www.global-customer.com/images/Wine_Four%20Roses%20Bourbon%20Whiskey/Four%20Roses%20Bourbon%20Whiskey_Wine_20.jpg"}
            };
        }

        //
        // GET: /Drinks/
        public ActionResult Index()
        {
            return View(drinks);
        }

        public ActionResult ShowDetails(int id)
        {
            var drinkDetails = drinks.FirstOrDefault(x => x.Id == id);
            return View(drinkDetails);
        }
    }
}