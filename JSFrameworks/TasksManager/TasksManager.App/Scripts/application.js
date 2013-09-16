(function () {

    var layout = new kendo.Layout("<div id='content'> </div>");
    var router = new kendo.Router();
    var viewModel = new ViewModels.get();
    var view = new View.get("Scripts/partials/");

    router.route("/login", function () {
        view.loadUserLoginForm()
        .then(function (loginFormHtml) {
            var vm = viewModel.loginViewModel(function (address) {
                router.navigate(address);
            });
            var v = new kendo.View(loginFormHtml, { model: vm });
            layout.showIn("#content", v);
        })
    });

    router.route("/register", function () {

        view.loadUserRegisterForm()
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

    router.route("/appointments", function () {
        view.loadUserAppointmentForm()
        .then(function (userAppForm) {
            var vm = viewModel.appointmentViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(userAppForm, { model: vm });
            layout.showIn("#content", v);
        });
    });

    router.route("/todo-lists", function () {
        view.loadUserTodoForm()
        .then(function (userTodoForm) {
            var vm = viewModel.todoViewModel(function (address) {
                router.navigate(address);
            });

            var v = new kendo.View(userTodoForm, { model: vm });
            layout.showIn("#content", v);
        });
    });

    router.route("/todo-list/:id", function (id) {
        view.loadSingleTodoList()
        .then(function (singleTodo) {
            viewModel.singleTodoListViewModel(id)
            .then(function (vm) {
                var view = new kendo.View(singleTodo, { model: vm });
                layout.showIn("#content", view);
            });
        });
    });

    router.route("/todo-list/:id/add-todo", function (id) {
        view.loadAddTodoForm()
        .then(function (addTodoForm) {
            viewModel.addTodoViewModel(id)
            .then(function (vm) {
                var view = new kendo.View(addTodoForm, { model: vm });
                layout.showIn("#content", view);
            });
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

        $("#app").on("click", "#viewAppointments", function () {
            router.navigate("/appointments");
        });

        $("#app").on("click", "#viewTodos", function () {
            router.navigate("/todo-lists");
        });

        $("#app").on("click", "#addTodo", function () {
          
            router.navigate("/todo-list/" + id + "/add-todo");
        });

        $("#app").on("click", "#viewAll", function () {
            persister.get("api").appointment.all().then(function (appointments) {
                var appointmentsKendo = new kendo.data.DataSource({
                    data: appointments
                });

                $("#all-appointments").kendoGrid({
                    dataSource: appointmentsKendo,
                    columns:
                    [{ field:"subject", title: "Subject", width: 130 },
                    { field: "description", title: "Description", width: 130 },
                    { field: "createdAt", title: "CreatedAt", width: 130 }]
                })
            });
        });

        $("#app").on("click", "#viewAllTodos", function () {
            persister.get("api").todo.all().then(function (todolist) {
                var todoListKendo = new kendo.data.DataSource({
                    data: todolist
                });

                $("#all-todo-list").kendoGrid({
                    dataSource: todoListKendo,
                    columns:
                    [{ field: "title", title: "title", width: 130 },
                    { command: { text: "View Details", click: showDetails } }]
                })
            });

            function showDetails(e) {

                e.preventDefault();
                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

                var id = dataItem.id;
                router.navigate("/todo-list/" + id)

            }
        });
    });

    $(function () {
        layout.render($("#app"));
        router.start();
        router.navigate("/login");
    });
}());