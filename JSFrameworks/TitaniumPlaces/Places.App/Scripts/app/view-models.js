/// <reference path="../libs/_references.js" />

window.ViewModels = (function () {
    var ViewModels = Class.create({
        init: function (persister) {
            this.persister = persister;
            return this;
        },

        loginViewModel: function (successCallback) {
            var self = this;
            var ViewModel = new kendo.observable({
                username: "",
                password: "",
                nickname: "",

                login: function () {
                    self.persister.user
                    .login(this.get("username"), this.get("password"))
                    .then(function () {
                        successCallback("/home");
                    })
                },
                logout: function () {
                    self.persister.user
                    .logout()
                    .then(function () {
                        successCallback("/login");
                    },
                    function () { alert("error") }
                    );

                },
                register: function () {
                    self.persister.user
                    .register(this.get("username"), this.get("password"), this.get("nickname"))
                    .then(function () {
                        successCallback("/home");
                    },
                    function () {
                        alert("error");
                    })
                }
            })
            return ViewModel;
        },

        placesViewModel: function (successCallback) {
            var self = this;
            var ViewModel = new kendo.observable({

                logout: function () {
                    self.persister.user
                    .logout()
                    .then(function () {
                        successCallback("/login");
                    },
                    function () { alert("error") }
                    );
                },

                viewPlaces: function () {
                    self.persister.place
                    .viewPlaces()
                    .then(function () {
                        successCallback("/places");
                    })
                }
            });

            return ViewModel;
        },

        singlePlaceViewModel: function (id) {
            return this.persister.place.viewSinglePlace(id)
            .then(function (place) {
                var viewModel = {
                    place: place
                };

                return kendo.observable(viewModel);
            });
        },

        uploadViewModel: function (id, imageUrl) {
            return this.persister.place.image(id, imageUrl)
            .then(function () {
                $("<div />")
                    .appendTo("#app")
                    .html("Image added successfully!")
                    .kendoWindow({
                        visible: false
                    }).data("kendoWindow")
                    .center()
                    .open();
                document.location.href = "#/places/" + id;
            });
        },

        commentViewModel: function (id) {
            var self = this;
            var viewModel = {
                content: "",
                submit: function () {
                    return self.persister.place.comment(id, this.get("content"))
                    .then(function () {
                        $("<div />")
                            .appendTo("#app")
                            .html("Comment added successfully!")
                            .kendoWindow({
                                visible: false
                            }).data("kendoWindow")
                            .center()
                            .open();
                        document.location.href = "#/places/" + id;
                    });
                }
            };

            return kendo.observable(viewModel);
        }
    });

    return {
        get: function () {
            return new ViewModels(persister.get("api"))
        },
    }
}());