using System.Web.Mvc;

namespace FoodAndAlchoholEverywhere.Areas.Recipes
{
    public class RecipesAreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "Recipes";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
		{
            context.MapRoute(
                "Recipes_default",
                "Recipes/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}