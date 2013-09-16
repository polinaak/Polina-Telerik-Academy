/// <reference path="../libs/jquery.min.js" />
/// <reference path="../libs/kendo.web.min.intellisense.js" />
/// <reference path="../libs/class.js" />
/// <reference path="../libs/rsvp.min.js" />


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

        loadLoginForm: function () {
            return this.loadPartialHtml("login-form");
        },

        loadUserHome: function(){
            return this.loadPartialHtml("user-home");
        },

        loadAboutForm: function () {
            return this.loadPartialHtml("about-form");
        }
    })

    return {
        get: function (rootUrl) {
            return new View(rootUrl);
        }
    }
}());