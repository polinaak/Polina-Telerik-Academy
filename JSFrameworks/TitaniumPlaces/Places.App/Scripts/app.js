/// <reference path="libs/_references.js" />

(function () {

    var layout = new kendo.Layout("<div id='content'> </div>");
    var router = new kendo.Router();
    var viewModel = new ViewModels.get();
    var view = new View.get("Scripts/partials/");

    router.route("/login", function () {
        view.loadLoginForm()
        .then(function (loginFormHtml) {
            var vm = viewModel.loginViewModel(function (address) {
                router.navigate(address);
            });
            var v = new kendo.View(loginFormHtml, { model: vm });
            layout.showIn("#content", v);
        })
    });

    router.route("/register", function () {

        view.loadRegisterForm()
        .then(function (registerFormHtml) {
            var vm = viewModel.loginViewModel(function (address) {
                router.navigate(address);
            });
            var v = new kendo.View(registerFormHtml, { model: vm });
            layout.showIn("#content", v);
        })
    });

    router.route("/home", function () {
        view.loadUserHome()
        .then(function (userHomeForm) {
            var vm = viewModel.loginViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(userHomeForm, { model: vm });
            layout.showIn("#content", v);
        });
    });

    router.route("/about", function () {

        view.loadAboutForm()
        .then(function (aboutForm) {

            var v = new kendo.View(aboutForm);
            layout.showIn("#content", v);

            $("#tabstrip").kendoTabStrip({
                animation: { open: { effects: "fadeIn" } },
                contentUrls: [
                            'Scripts/data/about1.html',
                            'Scripts/data/about2.html',
                            'Scripts/data/about3.html'
                ]
            })
        });
    });

    router.route("/places", function () {
        view.loadPlacesForm()
        .then(function (placesForm) {
            var vm = viewModel.placesViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(placesForm, { model: vm });
            layout.showIn("#content", v);

            persister.get("api").place.viewPlaces().then(function (places) {
                var placesKendo = new kendo.data.DataSource({
                    data: places
                });

                $("#allPlaces").kendoGrid({
                    dataSource: placesKendo,
                    columns:
                    [
                    { field: "name", title: "Name" },
                    { field: "content.substring(0, 50).concat('...')", title: "Content" },
                    { field: "town.name", title: "Town" },
                    { field: "country.name", title: "Country" },
                    { command: { text: "View Details", click: showDetails }, title: " ", width: "140px" }],
                    detailInit: function (e) {
                        var detailRow = e.detailRow;

                        var imagesDataSource = new kendo.data.DataSource({
                            data: places,
                            filter: { field: "id", operator: "eq", value: e.data.id }
                        });

                        detailRow.kendoListView({
                            dataSource: imagesDataSource,
                            template: kendo.template($("#listViewTemplate").html())
                        });
                    },
                    change: function (arg) {
                        var selected = $.map(this.select(), function (item) {
                            return $(item).text();
                        });

                        var id = selected[0];
                        router.navigate("/places/" + id);
                    }
                })

                function showDetails(e) {
                    e.preventDefault();
                    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                    var id = dataItem.id;
                    router.navigate("/places/" + id);
                }
            });
        })
    });

    router.route("/places/:id", function (id) {
        view.loadSinglePlace()
        .then(function (placeHtml) {
            viewModel.singlePlaceViewModel(id)
            .then(function (vm) {
                var view = new kendo.View(placeHtml, { model: vm });
                layout.showIn("#content", view);
            });
        });
    });

    router.route("/places/:id/addImage", function (id) {
        view.loadUploadForm()
            .then(function (form) {
                var view = new kendo.View(form);
                layout.showIn("#content", view);
                $("#submit").on("click", function (e) {
                    e.preventDefault();
                    ImageUploader.uploadImage("files", function (url) {
                        viewModel.uploadViewModel(id, url);
                    });
                });
            });
    });

    router.route("/places/:id/addComment", function (id) {
        view.loadCommentForm()
            .then(function (form) {
                var vm = viewModel.commentViewModel(id);
                var view = new kendo.View(form, { model: vm });
                layout.showIn("#content", view);
            });
    });

    $(document).ready(function () {
        $("#app").on("click", "#loadRegister", function () {
            router.navigate("/register");
        });

        $("#menu").on("click", "#logout", function () {
            persister.logout();
            router.navigate("/login");
        });

        $("#menu").on("click", "#btn-about", function () {
            router.navigate("/about");
        });

        $("#app").on("click", "#viewPlaces", function () {
            router.navigate("/places");
        });
    });

    $(function () {
        layout.render($("#app"));
        router.start("/");
        //router.navigate("/login");
    });
}());