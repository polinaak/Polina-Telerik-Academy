window.persister = (function () {
    var username = localStorage.getItem("username") || "";
    var accessToken = localStorage.getItem("accessToken") || "";

    function SaveUserData(usernameDb, accessTokenDb) {
        username = usernameDb;
        accessToken = accessTokenDb;

        localStorage.setItem("username", username);
        localStorage.setItem("accessToken", accessToken);
    }

    function ClearUserData() {
        username = "";
        accessToken = "";

        localStorage.removeItem("accessToken");
        localStorage.removeItem("username");
    }

    function userLoggedIn() {
        return accessToken != "";
    }

    if (userLoggedIn()) {
        showMenu();
    }
    else {
        window.location.replace("#/login");
        hideMenu();
    }

    function showMenu() {
        $(document).ready(function () {
            $("#greeting").text("Hello, " + username + "!");
            $("#menu").css("display", "block");
        });
    }

    function hideMenu() {
        $(document).ready(function () {
            $("#menu").hide();
        });
    }

    function logout() {
        var url = "api/users";

        return requester.put(url, {}, { "X-accessToken": accessToken })
           .then(function () {
               ClearUserData();
               hideMenu();
           });
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersiter(rootUrl);
            this.appointment = new AppointmentPersister(rootUrl);
            this.todo = new TodoPersister(rootUrl);
        }
    });

    var UserPersiter = Class.create({
        init: function (rootUrl) {
            this.userUrl = rootUrl + "/users";
        },

        login: function (username, authCode, email) {

            var url = "api/auth/token";
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(authCode).toString(),
                email: email
            };

            return requester.post(url, user)
             .then(function (data) {
                 SaveUserData(data.username, data.accessToken);
                 showMenu();
             },

             function (err) {
                 console.log(err);
             });
        },

        register: function (username, authCode, email) {
            var url = this.userUrl + "/register";

            var user = {
                username: username,
                authCode: CryptoJS.SHA1(authCode).toString(),
                email: email
            };

            return requester.post(url, user);
        }
    });

    var AppointmentPersister = Class.create({
        init: function (rootUrl) {
            this.appointmentUrl = rootUrl + "/appointments";
        },

        create: function (subject, description, appointmentDate,
        duration, state) {
            var url = this.appointmentUrl;

            var appointment = {
                subject: subject,
                description: description,
                appointmentDate: appointmentDate,
                duration: duration,
                createdAt: Date.now,
                state:state
            };
            return requester.post(url, appointment);
        },
        
        all: function () {
            var url = this.appointmentUrl + "/all";

            return requester.get(url, { "X-accessToken": accessToken });
        }
        
    });

    var TodoPersister = Class.create({
        init: function (rootUrl) {
            this.todosUrl = rootUrl + "/lists";
        },

        addList: function (title, todos) {
            var url = this.todosUrl;

            var todoList = {
                title: title,
                todos: [todos]
            };
            return requester.post(url, todoList);
        },

        addTodo: function (listId, text) {
            var url = this.todosUrl + "/" + listId + "/todos";
            var todo = {
                text: text
            };

            return requester.post(url, todo);
        },

        all: function () {
            var url = this.todosUrl;
            return requester.get(url, { "X-accessToken": accessToken });
        },

        viewSingleTodoList: function (listId) {
            var url = this.todosUrl + "/" + listId + "/todos";

            return requester.get(url, { "X-accessToken": accessToken });
        },

    });

    return {
        get: function (rootUrl) {
            return new MainPersister(rootUrl);
        },
        logout: logout
    }
}());