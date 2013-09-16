/// <reference path="app/persister.js" />
/// <reference path="app/requester.js" />
/// <reference path="app/view-models.js" />
/// <reference path="app/views.js" />
/// <reference path="libs/kendo.web.min.intellisense.js" />
/// <reference path="libs/jquery.min.js" />
/// <reference path="libs/kendo.web.min.js" />


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

    router.route("/home", function () {
        view.loadUserHome()
        .then(function (userHomeForm) {
            var vm = viewModel.transactionViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(userHomeForm, { model: vm });
            layout.showIn("#content", v);

            $(document).ready(function () {
                $("#calendar").kendoCalendar();
            });
        });
    });


    router.route("/about", function () {

        view.loadAboutForm()
        .then(function (aboutForm) {

            var vm = viewModel.loginViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(aboutForm, { model: vm });
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

    $(document).ready(function () {
        $("#app").on("click", "#btn-view-logs", function () {
            persister.get("api").transactions.viewLogs().then(function (logs) {
                var logsKendo = new kendo.data.DataSource({
                    data: logs
                });

                $("#view-logs").kendoGrid({
                    dataSource: logsKendo,
                    columns:
                    [{ field: "Date", title: "date", width: 130 },
                    { field: "Sum", title: "sum", width: 130 },
                    { field: "TransactionType", title: "type", width: 130 }]
                })
            });
        });
    });

    $(document).ready(function () {
        $("#app").on("click", "#btn-about", function () {
            router.navigate("/about");
        })
    });

    $(function () {
        layout.render($("#app"));
        router.start();
        router.navigate("/login");
    });

}());