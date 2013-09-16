window.ViewModels = (function () {


    var ViewModels = Class.create({
        init: function (persister) {
            this.persister = persister;
            return this;
        },

        loginViewModel: function (successCallback) {
            var self = this;
            var ViewModel = new kendo.observable({
                username: "polina",
                authCode: "polina",
                email: "polina@gmail.com",

                login: function () {
                    self.persister.user
                    .login(this.get("username"), this.get("authCode"), this.get("email"))
                    .then(function () {
                        successCallback("/home");
                    })
                },

                register: function () {
                    self.persister.user
                    .register(this.get("username"), this.get("authCode"), this.get("email"))
                    .then(function () {
                        successCallback("/login");
                    })
                }
            })
            return ViewModel;
        },

        singleTodoListViewModel: function (listId) {
            return this.persister.todo.viewSingleTodoList(listId)
            .then(function (list) {
                var viewModel = {
                    list: list
                };

                return kendo.observable(viewModel);
            });
        },

        addTodoViewModel: function (listId) {
            return this.persister.todo.addTodo(listId, this.get("text"))
            .then(function () {
                $("<div />")
                    .appendTo("#app")
                    .html("Todo added successfully!")
                    .kendoWindow({
                        visible: false
                    }).data("kendoWindow")
                    .center()
                    .open();
                document.location.href = "#/home";
            });
        },

        appointmentViewModel: function (successCallback) {
            var self = this;
            var viewModel = {
                subject: "",
                description: "",
                appointmentDate: "",
                duration: "",
                create: function () {
                    return self.persister.appointment.create(this.get("subject"), this.get("description"),
                        this.get("appointmentDate"), this.get("duration"))
                    .then(function () {
                        $("<div />")
                            .appendTo("#app")
                            .html("Appointment added successfully!")
                            .kendoWindow({
                                visible: false,
                                actions: ["Close"],
                                close: onClose
                            }).data("kendoWindow")
                            .center()
                            .open();
                        document.location.href = "#/appointments";
                    }, function (err) {
                        var response = JSON.parse(err.responseText);
                        self.set("infoMessage", response.Message);
                    });
                }
            };

            return kendo.observable(viewModel);
        },

        todoViewModel: function (successCallback) {
            var self = this;
            var viewModel = {
                title: "",
                todos: "",

                addList: function () {
                    return self.persister.todo.addList(this.get("title"), this.get("todos"))
                    .then(function () {
                        $("<div />")
                            .appendTo("#app")
                            .html("TODO list added successfully!")
                            .kendoWindow({
                                visible: false,
                                actions: ["Close"],
                                close: onClose
                            }).data("kendoWindow")
                            .center()
                            .open();
                        document.location.href = "#/home";
                    }, function (err) {
                        var response = JSON.parse(err.responseText);
                        self.set("infoMessage", response.Message);
                    });
                },


            };
            return kendo.observable(viewModel);
        }

    
    });
    return {
        get: function () {
            return new ViewModels(persister.get("api"))
        }
    }
}());