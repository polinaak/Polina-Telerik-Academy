/// <reference path="../libs/_references.js" />

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

        loadUserHome: function () {
            return this.loadPartialHtml("user-home");
        },

        loadRegisterForm: function () {
            return this.loadPartialHtml("register-form");
        },

        loadPlacesForm: function () {
            return this.loadPartialHtml("place-form");
        },

        loadSinglePlace: function(id){
            return this.loadPartialHtml("single-place");
        },

        loadUploadForm: function () {
            return this.loadPartialHtml("image-upload-form");
        },

        loadCommentForm: function () {
            return this.loadPartialHtml("comment-form");
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