function PlacesController($scope, $http) {

    $scope.newPlace = {
        name: "",
        content: "",
        townId: ""
    };

    $http.get("../api/countries/",
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            })
	.success(function (countries) {
	    $scope.countries = countries;
	});

    $scope.changeCountry = function () {
        var countryId = $scope.selectedCountry.id;

        var countryUrl = "../api/countries/" + countryId;
        $http.get(countryUrl,
               {
                   headers: {
                       'X-sessionKey': localStorage.getItem("sessionKey")
                   }
               })
       .success(function (singleCountry) {
           $scope.singleCountry = singleCountry;
       });
    };

    var townID;

    $scope.changeTown = function () {
        townID = $scope.selectedTown.id;
    };

    $scope.addPlace = function () {

        var data = {
            name: $scope.newPlace.name,
            content: $scope.newPlace.content,
            townId: townID
        };

        $http.post("../api/places", JSON.stringify(data),
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            });

        $scope.newPlace = {
            name: "",
            content: "",
            townId: ""
        };
    }
}

function CountriesController($scope, $http) {

    $scope.newCountry = {
        name: ""
    };

    $scope.addCountry = function () {

        var data = {
            name: $scope.newCountry.name
        };

        $http.post("../api/countries", JSON.stringify(data),
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            });

        $scope.newCountry = {
            name: ""
        };
    }
}

function TownsController($scope, $http) {

    $scope.newTown = {
        name: "",
        countryId: ""
    };

    $http.get("../api/countries/",
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            })
	    .success(function (countries) {
	        $scope.countries = countries;
	    });

    var countryID;

    $scope.change = function () {
        countryID = $scope.selectedCountry.id;
    }

    $scope.addTown = function () {

        var data = {
            name: $scope.newTown.name,
            countryId: countryID
        };

        $http.post("../api/towns", JSON.stringify(data),
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            });

        $scope.newTown = {
            name: "",
            countryId: ""
        };
    }
}

function UsersController($scope, $http) {

    $scope.editUser = {
        nickname: "",
        role: "",
        id: ""
    };

    $http.get("../api/users/",
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            })
	.success(function (users) {
	    $scope.users = users;
	    for (var i = 0; i < $scope.users.length; i++) {
	        $scope.users[i].role = ($scope.users[i].role == 1) ? "admin" : "user";
	    }
	});

    $scope.getId = function () {
        var that = this;
        document.getElementById("user-id").value = that.user.id;
        document.getElementById("tb-name").value = that.user.nickname;
        document.getElementById("tb-role").value = that.user.role;
    };

    $scope.edit = function () {

        var data = {
            nickname: $scope.editUser.nickname,
            role: document.getElementById("tb-role").value == "admin" ? 1 : 2,
            id: document.getElementById("user-id").value
        };
        console.log(data);
        var url = "../api/users/edit?id=" + data.id;
        $http.put(url, JSON.stringify(data),
            {
                headers: {
                    'X-sessionKey': localStorage.getItem("sessionKey")
                }
            }).success(function () {
                window.location.reload()
            });

        $scope.editUser = {
            nickname: "",
            role: "",
            id: ""
        };
    }
}