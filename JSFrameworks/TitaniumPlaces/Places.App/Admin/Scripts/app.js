angular.module("places", [])
	.config(["$routeProvider", function ($routeProvider) {
	    $routeProvider
			.when("/country", { templateUrl: "scripts/partials/add-country.html", controller: CountriesController })
			.when("/town", { templateUrl: "scripts/partials/add-town.html", controller: TownsController })
			.when("/", { templateUrl: "scripts/partials/add-place.html", controller: PlacesController })
			.when("/users", { templateUrl: "scripts/partials/users.html", controller: UsersController })
			.otherwise({ redirectTo: "/" });
	}]);