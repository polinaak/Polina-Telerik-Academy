window.View = (function () {
    var View = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.templates = {};
        },
        
        loadPartialHtml: function (name) {
            var self = this;
            var promise = new RSVP.Promise(function (resolve, reject) {
                if (self.templates[name]) {
                    resolve(self.templates[name]);
                } else {
                    $.ajax({
                        url: self.rootUrl + name + ".html",
                        type: "GET",
                        success: function (templateHtml) {
                            self.templates[name] = templateHtml;
                            resolve(self.templates[name]);
                        },
                        error: function (err) {
                            reject(err);
                        }
                    })
                }
            });
            return promise;
        },

        loadUserLoginForm: function() {
            return this.loadPartialHtml("login-form");
        },
        loadUserHome: function () {
            return this.loadPartialHtml("user-home");
        },
        loadUserRegisterForm: function () {
            return this.loadPartialHtml("register-form");
        },
        loadUserAppointmentForm: function () {
            return this.loadPartialHtml("appointments-form");
        },
        loadUserTodoForm: function () {
            return this.loadPartialHtml("todo-form");
        },
        loadSingleTodoList: function () {
            return this.loadPartialHtml("single-todo-form");
        },
        loadAddTodoForm: function () {
            return this.loadPartialHtml("add-todo-form");
        }

    })

    return {
        get: function (rootUrl) {
            return new View(rootUrl);
        }
    }
}());