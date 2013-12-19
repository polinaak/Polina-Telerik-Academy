/// <reference path="../libs/_references.js" />

window.persister = (function () {
    var sessionKey = localStorage.getItem("sessionKey") || "";
    var nickname = localStorage.getItem("nickname") || "";

    function userLoggedIn() {
        return sessionKey != "";
    }

    if (userLoggedIn()) {        
        showMenu();
    }
    else {
        window.location.replace("index.html#/login");
        hideMenu();
    }

    function SaveUserData(nicknameDb, sessionKeyDb) {
        nickname = nicknameDb;
        sessionKey = sessionKeyDb;

        localStorage.setItem("nickname", nickname);
        localStorage.setItem("sessionKey", sessionKey);
    }

    function ClearUserData() {
        sessionKey = "";
        nickname = "";

        localStorage.removeItem("sessionKey");
        localStorage.removeItem("nickname");
    }

    function showMenu() {
        $(document).ready(function () {
            $("#greeting").text("Hello, " + nickname + "!");
            $("#menu").css("display", "block");
        });       
    }

    function hideMenu() {
        $(document).ready(function () {
            $("#menu").hide();
        });
    }

    function logout() {
        var url = "api/users/logout";

        return requester.put(url, {}, { "X-sessionKey": sessionKey })
           .then(function () {
               ClearUserData();
               hideMenu();
           });
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersiter(rootUrl);
            this.place = new PlacesPersister(rootUrl);
        }
    });

    var UserPersiter = Class.create({
        init: function (rootUrl) {
            this.userUrl = rootUrl + "/users";
        },

        login: function (username, password) {

            var url = this.userUrl + "/login";
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return requester.post(url, user)
             .then(function (data) {
                 SaveUserData(data.nickname, data.sessionKey);
                 showMenu();
             },

             function (err) {
                 console.log(err);
             });
        },

        register: function (username, password, nickname) {

            var url = this.userUrl + "/register";
            var user = {
                username: username,
                nickname: nickname,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return requester.post(url, user)
            .then(function (data) {
                SaveUserData(data.nickname, data.sessionKey);
                showMenu();
            },

            function (err) {
                console.log(err);
            });
        }
    });

    var PlacesPersister = Class.create({
        init: function (rootUrl) {
            this.placesUrl = rootUrl + "/places";
        },

        viewPlaces: function () {
            return requester.get(this.placesUrl, { "X-sessionKey": sessionKey });
        },

        viewSinglePlace: function (id) {
            return requester.get(this.placesUrl + "/" + id, { "X-sessionKey": sessionKey });
        },

        image: function (id, imageUrl) {
            var image = {
                imageUrl: imageUrl
            };

            return requester.post(this.placesUrl + "/" + id + "/image", image, { "X-sessionKey": sessionKey });
        },

        comment: function (id, content) {
            var comment = {
                content: content
            };

            return requester.post(this.placesUrl + "/" + id + "/comment", comment, { "X-sessionKey": sessionKey });
        }
    });

    return {
        get: function (rootUrl) {
            return new MainPersister(rootUrl);
        },
        logout: logout
    }
}());